using System.Runtime.CompilerServices;
using nightowlsign.data;
using System.ComponentModel.DataAnnotations;

namespace SignSystem.DTO.Models.Store
{
    public class UpdateStoreDto: StoreDto
    {
        public int Id { get; set; }
    }
    public class StoreDto
    {
        [Required]
        [MinLengthAttribute(1)]
        public string Name { get; set; }
        public string Suburb { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Manager { get; set; }
        public string IpAddress { get; set; }
        public string SubMask { get; set; }
        public string Port { get; set; }
        public string ProgramFile { get; set; }
        public int NumImages { get; set; }
        public int? SignId { get; set; }
        public Sign sign => new Sign() { id = SignId ?? 0 };
    }

}
