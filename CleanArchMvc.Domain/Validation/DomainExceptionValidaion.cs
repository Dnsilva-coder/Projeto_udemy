using System.Drawing;

namespace CleanArchMvc.Domain.Validation
{
    public class DomainExceptionValidaion : Exception
    {
        public DomainExceptionValidaion(string error) : base(error)
        { }

        public static void When(bool hasErro,string error)
        {
            if (hasErro)
            {
                throw new DomainExceptionValidaion(error);
            }
        }
    }
}
