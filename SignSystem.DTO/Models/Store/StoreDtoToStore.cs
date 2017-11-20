using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nightowlsign.data;

namespace SignSystem.DTO.Models.Store
{
    public class StoreDtoToStore
    {
        public StoreDtoToStore()
        {
        }
        public nightowlsign.data.Store CreateStore(UpdateStoreDto storeDto)
        {
            return new nightowlsign.data.Store()
            {
                id = storeDto.Id,
                Address = storeDto.Address,
                Name = storeDto.Name,
                IpAddress = storeDto.IpAddress,
                SubMask = storeDto.SubMask,
                Port = storeDto.Port,
                Manager = storeDto.Manager,
                ProgramFile = storeDto.ProgramFile,
                NumImages = storeDto.NumImages,
                SignId = storeDto.SignId,
                Suburb = storeDto.Suburb
            };
        }

        public nightowlsign.data.Store CreateNewStore(StoreDto storeDto)
        {
            return new nightowlsign.data.Store()
            {
                Address = storeDto.Address,
                Name = storeDto.Name,
                IpAddress = storeDto.IpAddress,
                SubMask = storeDto.SubMask,
                Port = storeDto.Port,
                Manager = storeDto.Manager,
                ProgramFile = storeDto.ProgramFile,
                NumImages = storeDto.NumImages,
                SignId = storeDto.SignId,
                Suburb = storeDto.Suburb
            };
        }
    }
}
