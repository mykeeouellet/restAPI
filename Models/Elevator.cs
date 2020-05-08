using System;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
public class Elevator
{
    public long id { get; set; }
    public string elevator_serial_number { get; set; }
    public string elevator_model { get; set; }
    public string building_type { get; set; }
    public string elevator_status { get; set; }
    public DateTime elevator_commissioning_date { get; set; }
    public DateTime elevator_inspection_date { get; set; }
    public string elevator_certificate_inspection { get; set; }
    public string elevator_information { get; set; }
    public string elevator_notes { get; set; }
    public long column_id { get; set; }
    public Column columns { get; set; }
}