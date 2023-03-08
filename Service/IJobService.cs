using Nupat_CSharp.Models;
using Nupat_CSharp.ViewModel;

namespace Nupat_CSharp.Service
{
    public interface IJobService
    {
        // list jobs
        Task<List<Job>> GetJobs();

        // add job

        Task<Job> AddJob(JobViewModel jobViewModel);

        // Get Job by Id
        Task<Job> GetJobById(Guid Id);

        //Delete by Id
        Task DeleteJob(Job obj);

        Task<Job> Edit(Job obj);
        

    }
}
