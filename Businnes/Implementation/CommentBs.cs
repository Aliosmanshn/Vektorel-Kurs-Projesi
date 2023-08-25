using AutoMapper;
using Businness.CustomExceptions;
using Businness.Interfaces;
using CommonTypes.Utilities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Model.Dtos.CommentDto;
using Model.Entities;

namespace Businness.Implementation
{
    public class CommentBs : ICommentBs

    {
        private readonly ICommentRepository _commentRepository; //dışarıdan erisim yok
        private readonly IMapper _mapper;
        public CommentBs(IMapper mapper , ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }


        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var comment = await _commentRepository.GetByIDAsync(id);

            await _commentRepository.DeleteAsync(comment);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<CommentGetDto>>> GetAsync(params string[] includeList)
        {
            var comment = await _commentRepository.GetAllAsync(includeList: includeList);
            if (comment.Count > 0)
            {
                var addressList = _mapper.Map<List<CommentGetDto>>(comment);
                var response = ApiResponse<List<CommentGetDto>>.Success(StatusCodes.Status200OK, addressList);

                return response;
            }

            throw new NotFoundException("Adres bulunamadı");
        }

        public async Task<ApiResponse<CommentGetDto>> GetByIDAsync(int Id, params string[] includeList)
        {
            var comment = await _commentRepository.GetByIDAsync(Id , includeList);

            if (comment != null)
            {
                var dto = _mapper.Map<CommentGetDto>(comment);
                return ApiResponse<CommentGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");
        }

        public async Task<ApiResponse<Comment>> InsertAsync(CommentPostDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var comment = _mapper.Map<Comment>(entity);
            var insertedAddress = await _commentRepository.InsertAsync(comment);
            return ApiResponse<Comment>.Success(StatusCodes.Status200OK, insertedAddress);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(CommentPutDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var comment = _mapper.Map<Comment>(entity);
            await _commentRepository.UpdateAsync(comment);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
