//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AluraTunes2.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Faixa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Faixa()
        {
            this.ItemNotaFiscals = new HashSet<ItemNotaFiscal>();
            this.Playlists = new HashSet<Playlist>();
        }
    
        public int FaixaId { get; set; }
        public string Nome { get; set; }
        public Nullable<int> AlbumId { get; set; }
        public int TipoMidiaId { get; set; }
        public Nullable<int> GeneroId { get; set; }
        public string Compositor { get; set; }
        public int Milissegundos { get; set; }
        public Nullable<int> Bytes { get; set; }
        public decimal PrecoUnitario { get; set; }
    
        public virtual Album Album { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual TipoMidia TipoMidia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemNotaFiscal> ItemNotaFiscals { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
