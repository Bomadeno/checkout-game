using System.Collections.Generic;
using UnityEngine;

public class CustomerVisitScore
{
    public string CustomerName;
    public int NumberOfItemsInBasket;
    public int NumberOfItemsScanned;

}

public class DayRecord
{
    public float UnpaidOvertimeSeconds;
    public List<CustomerVisitScore> customers;
}

public class Score : MonoBehaviour
{
	private static Score instance;
	public static Score Instance { get { return instance;}}
	void Awake()
	{
		instance=this;
	}
    public List<DayRecord> AllDays = new List<DayRecord>(); 
    public List<CustomerVisitScore> DaysVisits = new List<CustomerVisitScore>();
    public float TimeDayStarted;
    public float DayLengthSeconds = 120; //2 minutes

    /// <summary>
    /// Call when you "open" the checkout for the first customer
    /// </summary>
    public void StartDay()
    {
        TimeDayStarted = Time.time;
        DaysVisits = new List<CustomerVisitScore>();
    }

    /// <summary>
    /// When the customer queue is done!
    /// </summary>
    public void FinishDay()
    {
        DayRecord theDay = new DayRecord();
        float timeToFinishCustomers = Time.time - TimeDayStarted;
        theDay.UnpaidOvertimeSeconds = Mathf.Clamp(timeToFinishCustomers - DayLengthSeconds, 0, 5000);

        theDay.customers = DaysVisits;
        AllDays.Add(theDay);
    }

    /// <summary>
    /// Call this when you finish a customer. Currently only tracks items, not speech events
    /// </summary>
    /// <param name="c">The customer that just finished.</param>
    public void LogCustomerExperience(Customer c)
    {
        CustomerVisitScore scoreInstance = new CustomerVisitScore {CustomerName = c.gameObject.name};
        foreach (var moveItem in c.bascket)
        {
            scoreInstance.NumberOfItemsInBasket++;
            if (moveItem.IsScanned)
            {
                scoreInstance.NumberOfItemsScanned++;
            }
        }
        DaysVisits.Add(scoreInstance);
    }

    public override string ToString()
    {
        return "Score sheet:";
        //todo: gui for time left in day, customers left in queue 
        //todo gui for score summary
    }

	void OnGUI () {
        GUI.Label(new Rect(0,0,500,40), "Score");
	
	}
}
