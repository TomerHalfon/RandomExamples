using System;

namespace Library
{
    //Create a delegate to which the ui will add methods to change the view of the Amount Property
    public delegate void UpdatedAmount();
    public class Manager
    {
        //Create a "Suite" of methods wich have the UpdateAmount delegate signiture
        public UpdatedAmount updatedAmount;
        decimal _amount = 0;
        //when ever we change the property we want to update the UI as the UI wants us to, the way to do that is to invoke the "Suite"
        public decimal Amount { get { return _amount; } private set { _amount = value; updatedAmount?.Invoke(); } }
        public void UpdateAmount()
        {
            Amount += 50;
        }
    }
}
