using Api.Helpers;
using Api.Models;
using Api.Services;
using Api.View;
using Api.ViewModel.Interface;
using AutoMapper;
using Data;
using Data.Clients;
using Data.Models;
using Financ.Api.ViewModel;
using System.Collections.Generic;

namespace Api.ViewModel
{
    public class PhotoViewModel : BaseViewModel, IPhotoViewModel
    {
        public IMapper Mapper => _mapper;
        public PhotographerContext Context => _context;
        private readonly PhotoRep _Rep;
        private IStorageService _storage { get; set; }
        public PhotoViewModel(PhotographerContext context, IMapper mapper, IStorageService storageService)
            : base(context, mapper)
        {
            _Rep = new PhotoRep(_context);
            _storage = storageService;
        }

        public async Task Insert(EntityPhotoView view)
        {
            var model = _Rep.Save(_mapper.Map<EntityPhoto>(view));

            await _context.SaveChangesAsync();

            _mapper.Map(model, view);
        }

        public async Task InsertList(List<EntityPhotoView> list)
        {
            foreach (var item in list)
            {
                try
                {
                    if (item.FileData != null && item.FileData.File != null)
                        item.Url = await _storage.SaveImageAsync(item.FileData);
                }
                catch (Exception)
                {
                    throw;
                }
                _Rep.Save(_mapper.Map<EntityPhoto>(item));
            }

            await _context.SaveChangesAsync();

            //_mapper.Map(model, list);
        }

        public async Task Update(EntityPhotoView view)
        {
            var model = _Rep.Save(_mapper.Map<EntityPhoto>(view));

            await _context.SaveChangesAsync();

            _mapper.Map(model, view);
        }

        public async Task<Task> Delete(EntityPhotoView view)
        {
            _Rep.Delete(_mapper.Map<EntityPhoto>(view));

            await _context.SaveChangesAsync();

            return Task.CompletedTask;
        }

        public async Task<List<EntityPhotoView>> GetAll()
        {
            var result = await _Rep.GetAll();

            return _mapper.Map<List<EntityPhotoView>>(result);
        }

        public async Task<List<EntityPhotoView>> GetAllBySector(Guid idSector)
        {
            var result = await _Rep.GetAllBySector(idSector);

            var photoViews = _mapper.Map<List<EntityPhotoView>>(result);

            foreach (var photoView in photoViews)
            {
                var imageBytes = await _storage.LoadImageAsync(photoView.Url); 
                photoView.FileData = new FileData { Bytes = imageBytes }; 
            }

            return photoViews;
        }


    }
}
