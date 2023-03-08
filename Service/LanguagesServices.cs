using Microsoft.EntityFrameworkCore;
using Nupat_CSharp.Data;
using Nupat_CSharp.Models;
using Nupat_CSharp.ViewModel;

namespace Nupat_CSharp.Service
{
    public class LanguagesServices : ILanguageService
    {
        private readonly DataContext _dataContext;
        public LanguagesServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Languages> AddLanguage(LanguageViewModel languageViewModel)
        {
            Languages lan = new Languages()
            {
                Id = Guid.NewGuid(),
                Name = languageViewModel.Name,
            };

            var obj = await _dataContext.Languages.AddAsync(lan);
            await _dataContext.SaveChangesAsync();
            return lan;
        }

        public async Task Deletelanguage(Languages obj)
        {
            _dataContext.Languages.Remove(obj);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Languages> Edit(Languages obj)
        {
            var lan = _dataContext.Languages.Update(obj);
            await _dataContext.SaveChangesAsync();
            return obj;
        }

        public async Task<Languages> GetLanguageById(Guid Id)
        {
            var obj = await _dataContext.Languages.FindAsync(Id);
            // var objs = await _dataContext.Job.Where(x => x.Id == Id).FirstAsync();

            return obj;
        }

        public async Task<List<Languages>> Getlanguages()
        {
            var lans = await _dataContext.Languages.ToListAsync();
            return lans; 
        }
    }
}
