using AutoMapper;
using Businness.CustomExceptions;
using Businness.Interfaces;
using CommonTypes.Utilities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Model.Dtos.UserDto;
using Model.Entities;

namespace Businness.Implementation
{
    public class UserBs : IUserBs

    {
        private readonly IUserRepository _userRepository; //dışarıdan erisim yok
        private readonly IMapper _mapper;
        public UserBs(IMapper mapper , IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIDAsync(id);

            await _userRepository.DeleteAsync(user);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<UserGetDto>>> GetAsync(params string[] includeList)
        {
            var user = await _userRepository.GetAllAsync(includeList: includeList);
            if (user.Count > 0)
            {
                var userList = _mapper.Map<List<UserGetDto>>(user);
                var response = ApiResponse<List<UserGetDto>>.Success(StatusCodes.Status200OK, userList);

                return response;
            }

            throw new NotFoundException("Adres bulunamadı");
        }

        public async Task<ApiResponse<UserGetDto>> GetByIDAsync(int Id, params string[] includeList)
        {
            var user = await _userRepository.GetByIDAsync(Id , includeList);

            if (user != null)
            {
                var dto = _mapper.Map<UserGetDto>(user);
                return ApiResponse<UserGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");
        }

        public async Task<ApiResponse<User>> InsertAsync(UserPostDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var user = _mapper.Map<User>(entity);
            var insertedUser = await _userRepository.InsertAsync(user);
            return ApiResponse<User>.Success(StatusCodes.Status200OK, insertedUser);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(UserPutDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var user = _mapper.Map<User>(entity);
            await _userRepository.UpdateAsync(user);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
