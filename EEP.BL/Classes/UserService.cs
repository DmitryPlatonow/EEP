using EEP.DAL.UnitOfWork;

namespace EEP.BL.Classes
{
    public class UserService //: IDisposable
    {
        private readonly UnitOfWork _unitOfWork;

        public UserService()
        {
            _unitOfWork = new UnitOfWork();            
        }       

    }
}
