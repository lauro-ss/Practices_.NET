﻿namespace Core
{
#nullable disable
    public class Categoria
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
