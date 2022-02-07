﻿namespace Application.Dto
{
    public class ProductosDto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }

        public int CategoriaId { get; set; }
        //[ForeignKey("CategoriaId")]
        public CategoriasDto Categorias { get; set; }
    }
}
