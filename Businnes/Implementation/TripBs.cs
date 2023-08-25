using AutoMapper;
using Businness.CustomExceptions;
using Businness.Interfaces;
using CommonTypes.Utilities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Model.Dtos.TripDto;
using Model.Entities;

namespace Businness.Implementation
{
    public class TripBs : ITripBs

    {
        private readonly ITripRepository _tripRepository; //dışarıdan erisim yok
        private readonly IMapper _mapper;
        public TripBs(IMapper mapper , ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }


        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var trip = await _tripRepository.GetByIDAsync(id);

            await _tripRepository.DeleteAsync(trip);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<TripGetDto>>> GetAsync(params string[] includeList)
        {
            var trip = await _tripRepository.GetAllAsync(includeList: includeList);
            if (trip.Count > 0)
            {
                var tripList = _mapper.Map<List<TripGetDto>>(trip);
                var response = ApiResponse<List<TripGetDto>>.Success(StatusCodes.Status200OK, tripList);

                return response;
            }

            throw new NotFoundException("Adres bulunamadı");
        }

        public async Task<ApiResponse<TripGetDto>> GetByIDAsync(int Id, params string[] includeList)
        {
            var trip = await _tripRepository.GetByIDAsync(Id , includeList);

            if (trip != null)
            {
                var dto = _mapper.Map<TripGetDto>(trip);
                return ApiResponse<TripGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");
        }

        public async Task<ApiResponse<Trip>> InsertAsync(TripPostDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var trip = _mapper.Map<Trip>(entity);
            var insertedTrip = await _tripRepository.InsertAsync(trip);
            return ApiResponse<Trip>.Success(StatusCodes.Status200OK, insertedTrip);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(TripPutDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var trip = _mapper.Map<Trip>(entity);
            await _tripRepository.UpdateAsync(trip);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
