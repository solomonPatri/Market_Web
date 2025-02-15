using Market_Web.System;

namespace Market_Web.Markets.Exceptions
{
    public class MarketAlreadyExistException:Exception
    {

        public MarketAlreadyExistException() : base(ExceptionMessage.MarketAlreadyExistException)
        {

        }


    }
}
