﻿using System;

namespace Chat.Domain.Contatos.Dto
{
    public class ContatoStatusDto
    {
        public int ContatoId { get; set; }
        public bool Online { get; set; }
        public DateTime Data { get; set; }
    }
}
