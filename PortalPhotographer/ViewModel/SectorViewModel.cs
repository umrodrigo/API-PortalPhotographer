using Api.View;
using Api.ViewModel.Interface;
using AutoMapper;
using Data;
using Data.Clients;
using Data.Models;
using Financ.Api.ViewModel;

namespace Api.ViewModel
{
    public class SectorViewModel : BaseViewModel, ISectorViewModel
    {
        public IMapper Mapper => _mapper;
        public PhotographerContext Context => _context;
        private readonly SectorRep _Rep;
        public SectorViewModel(PhotographerContext context, IMapper mapper)
            : base(context, mapper)
        {
            _Rep = new SectorRep(_context);
        }

        public async Task Insert(EntitySectorView view)
        {
            var model = _Rep.Save(_mapper.Map<EntitySector>(view));

            await _context.SaveChangesAsync();

            _mapper.Map(model, view);
        }

        public async Task Update(EntitySectorView view)
        {
            var model = _Rep.Save(_mapper.Map<EntitySector>(view));

            await _context.SaveChangesAsync();

            _mapper.Map(model, view);
        }

        public async Task<Task> Delete(EntitySectorView view)
        {
            _Rep.Delete(_mapper.Map<EntitySector>(view));

            await _context.SaveChangesAsync();

            return Task.CompletedTask;
        }

        public async Task<List<EntitySectorView>> GetAll()
        {
            var result = await _Rep.GetAll();

            return _mapper.Map<List<EntitySectorView>>(result);
        }
    }
}
