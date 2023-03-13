namespace Nupat_CSharp.Service
{
    public class Test : ITest
    {
        public int RandomNumber()
        {
            Random random = new Random();   
            return random.Next();
        }
    }
}
