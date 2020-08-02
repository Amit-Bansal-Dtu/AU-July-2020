using System;
using System.Collections.Generic;
using System.Linq;

public class TechLead{
    public string name{
        get;
        set;
    }

    public string emp_id{
        get;
        set;
    }
}

public class Manager{
    public string name{
        get; 
        set;
    }
    public string emp_id{
        get; 
        set;
    }
}

public class Joining
{
	static void Main(string[] args)
        {
            List<TechLead> TechLeads = new List<TechLead>{
                new TechLead {name="Amit Bansal", emp_id="101"},
                new TechLead {name="Rahul Pandit", emp_id="102"},
                new TechLead {name="Rakesh Sharma", emp_id="103"},
                new TechLead {name="Sushma Verma", emp_id="104"},
            };

            List<Manager> Managers = new List<Manager>{
                new Manager {name="Amit Bansal", emp_id="101"},
                new Manager {name="Rakesh Sharma", emp_id="103"},
                new Manager {name="Virat Singhal", emp_id="105"},
                new Manager {name="Sahil Gupta", emp_id="108"},
            };

            var Tech_managers = from TL in TechLeads
                                join M in Managers
                                on new {TL.name, TL.emp_id}
                                equals new {M.name, M.emp_id}
                                select TL.name;

            foreach(var x in Tech_managers){
                Console.WriteLine(x);
            }
        }
}
