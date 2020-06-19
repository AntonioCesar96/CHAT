﻿using Chat.Application.Contatos.Interfaces;
using Chat.Application.ContatosStatus.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Chat.Api.Hubs
{
    public class ConexaoHub
    {
        private readonly IHubContext<ChatHub, IChatCliente> _hubContext;
        private readonly IAtualizadorDeContatoStatusApplication _atualizadorDeContatoStatus;
        private readonly IRegistradorDeConexaoApplication _registradorDeConexao;
        private readonly IConsultaConnectionsDeAmigosApplication _consultaContatoStatusDeAmigos;
        private readonly IContatoStatusRepositorioApplication _contatoStatusRepositorio;

        public ConexaoHub(
            IHubContext<ChatHub, IChatCliente> hubContext,
            IAtualizadorDeContatoStatusApplication atualizadorDeContatoStatus,
            IRegistradorDeConexaoApplication registradorDeConexao,
            IConsultaConnectionsDeAmigosApplication consultaContatoStatusDeAmigos,
            IContatoStatusRepositorioApplication contatoStatusRepositorio)
        {
            _hubContext = hubContext;
            _atualizadorDeContatoStatus = atualizadorDeContatoStatus;
            _registradorDeConexao = registradorDeConexao;
            _consultaContatoStatusDeAmigos = consultaContatoStatusDeAmigos;
            _contatoStatusRepositorio = contatoStatusRepositorio;
        }

        public async Task RegistrarConexao(string connectionId, int contatoId)
        {
            var ids = await _registradorDeConexao.Registrar(contatoId, connectionId);
            await _hubContext.Clients.Clients(ids).Deslogar();

            var connectionsContato = _consultaContatoStatusDeAmigos.Consultar(contatoId);
            await _hubContext.Clients.Clients(connectionsContato)
                .ReceberStatusContatoOnline(contatoId);
        }

        public async Task Desconectar(string connectionId)
        {
            var dto = await _atualizadorDeContatoStatus.AtualizarParaOffline(connectionId);

            var connectionsContato = _consultaContatoStatusDeAmigos.Consultar(dto.ContatoId);
            await _hubContext.Clients.Clients(connectionsContato)
                .ReceberStatusContatoOffline(dto);
        }

        public async Task ObterStatusDoContato(string connectionId, int contatoId)
        {
            var dto = _contatoStatusRepositorio.ObterPorContato(contatoId);

            await _hubContext.Clients.Client(connectionId)
                .ReceberStatusDoContato(dto);
        }
    }
}
