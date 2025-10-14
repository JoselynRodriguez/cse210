using System; 

public class Swimming : Activity {
    
  protected int _numberOfLaps;

  public Swimming(string date, int minutes, int laps): base (date, minutes)
    {
      _numberOfLaps = laps;
    }

  public override double GetDistance()
  {
    return _numberOfLaps * 50/1000 ;
  }
  public override double GetSpeed()
  {
    return GetDistance()/ GetMinutes();
  }
  public override double GetPace()
  {
    return GetMinutes() / GetDistance();
  }
  
}
