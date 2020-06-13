﻿
using System;

namespace Chat.Domain.Contatos.Dto
{
    public class ContatoMensagemDto
    {
        public int ContatoId { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string FotoUrl { get; set; }
        public bool? Online { get; set; }
        public DateTime? DataRegistroOnline { get; set; }
    }
}
