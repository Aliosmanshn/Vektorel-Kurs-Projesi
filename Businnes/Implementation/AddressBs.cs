using AutoMapper;
using Businness.CustomExceptions;
using Businness.Interfaces;
using CommonTypes.Utilities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Model.Dtos.AddressDto;
using Model.Entities;

namespace Businness.Implementation
{
    public class AddressBs : IAddressBs
     
    {
        private readonly IAddressRepository _addressRepository; //dışarıdan erisim yok
        private readonly IMapper _mapper;
        public AddressBs(IMapper mapper , IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }


        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var address = await _addressRepository.GetByIDAsync(id);

            await _addressRepository.DeleteAsync(address);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<AddressGetDto>>> GetAsync(params string[] includeList)
        {
            var address = await _addressRepository.GetAllAsync(includeList: includeList);
            if (address.Count > 0)
            {
                var addressList = _mapper.Map<List<AddressGetDto>>(address);
                var response = ApiResponse<List<AddressGetDto>>.Success(StatusCodes.Status200OK, addressList);

                return response;
            }

            throw new NotFoundException("Adres bulunamadı");
        }

        public async Task<ApiResponse<AddressGetDto>> GetByIDAsync(int Id, params string[] includeList)
        {
            var address = await _addressRepository.GetByIDAsync(Id , includeList);

            if (address != null)
            {
                var dto = _mapper.Map<AddressGetDto>(address);
                return ApiResponse<AddressGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");
        }

        public async Task<ApiResponse<Address>> InsertAsync(AddressPostDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var address = _mapper.Map<Address>(entity);
            var insertedAddress = await _addressRepository.InsertAsync(address);
            return ApiResponse<Address>.Success(StatusCodes.Status200OK, insertedAddress);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(AddressPutDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var address = _mapper.Map<Address>(entity);
            await _addressRepository.UpdateAsync(address);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
