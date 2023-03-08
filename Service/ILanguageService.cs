using Nupat_CSharp.Models;
using Nupat_CSharp.ViewModel;

namespace Nupat_CSharp.Service
{
    public interface ILanguageService
    {
        // list jobs
        Task<List<Languages>> Getlanguages();

        // add job

        Task<Languages> AddLanguage(LanguageViewModel languageViewModel);

        // Get Job by Id
        Task<Languages> GetLanguageById(Guid Id);

        //Delete by Id
        Task Deletelanguage(Languages obj);
        //Edit
        Task<Languages> Edit(Languages obj);
    }
}
