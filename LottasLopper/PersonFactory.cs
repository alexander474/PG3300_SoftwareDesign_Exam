using System.Threading;

namespace LottasLopper{
  public class PersonFactory{

    public void CreateSellers(int numberOfSellers){
      for (int i = 0; i < numberOfSellers; i++){
        new Thread(newSeller).Start();
      }
    }
    
    public void CreateCustomers(int numberOfCustomers){
      for (int i = 0; i < numberOfCustomers; i++){
        new Thread(newCustomer).Start();
      }
    }

    void newSeller(){
      new Seller();
    }

    void newCustomer(){
      new Customer();
    }
  }
}
