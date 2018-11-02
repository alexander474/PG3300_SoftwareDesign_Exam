using System;
using Faker;

namespace LottasLopper{
  public abstract class Person{
    public Person(){
      Action(RandomNumber.Next(50, 200));
    }
    
    public abstract void Action(int actions);
  }
}
