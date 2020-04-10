	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Collections.Generic;
	public class Interventions
	{
	    public long Id { get; set; }
        public string author {get; set;}
	    public string result { get; set; }
	    public string report { get; set; }
	    public string status { get; set; }
	    public long column_id { get; set; }
	    public long battery_id { get; set; }
	    public long building_id { get; set; }
		public long customer_id { get; set; }
		public long elevator_id { get; set; }

        public long employee_id {get; set;}
	     public DateTime? intervention_starting_date_time { get; set; }
	
	    public DateTime? intervention_ending_date_time { get; set; }
    }