using Microsoft.EntityFrameworkCore;
using Nupat_CSharp.Data;
using Nupat_CSharp.Models;
using Nupat_CSharp.ViewModel;

namespace Nupat_CSharp.Service
{
    public class JobService : IJobService
    {
        private readonly DataContext _dataContext;
        public JobService(DataContext dataContext)
        {
            _dataContext = dataContext;  
        }

        public async Task<Job> AddJob(JobViewModel jobViewModel)
        {
            Job job = new Job()
            {
                Id = Guid.NewGuid(),
                Title = jobViewModel.Title, 
                Salary = jobViewModel.Salary,
                Qualification = jobViewModel.Qualification, 
                Experience = jobViewModel.Experience,   
            };

            var obj = await _dataContext.Job.AddAsync(job);
            await _dataContext.SaveChangesAsync();
            return job; 
        }

        public async Task DeleteJob(Job obj)
        {
            _dataContext.Job.Remove(obj);  
            await _dataContext.SaveChangesAsync();
            
        }

        public async Task<Job> Edit(Job obj)
        {
            var job = _dataContext.Job.Update(obj);
            await _dataContext.SaveChangesAsync();
            return obj;
        }

        public async Task<Job> GetJobById(Guid Id)
        {

            var obj = await _dataContext.Job.FindAsync(Id);  
           // var objs = await _dataContext.Job.Where(x => x.Id == Id).FirstAsync();

            return obj;
        }

        public async Task<List<Job>> GetJobs()
        {
            var jobs = await _dataContext.Job.ToListAsync();
            return jobs;
        }
    }
}
