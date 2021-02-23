using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace TicketingSystem
{
    public class ManageTicket
    {
        public Ticket askTicketInformation(string file) {
            
            Ticket ticket = new Ticket();

            // TicketID
             ticket.ticketID = ticket.ticketID = calculateTicketID(file);
            // Summary
            Console.WriteLine("Enter the summary: ");
            ticket.summary = Console.ReadLine();
            
            // Status
            Console.WriteLine("Enter the status: ");
            ticket.status = Console.ReadLine();
            
            // Priority
            Console.WriteLine("Enter the priority: ");
            ticket.priority = Console.ReadLine();
            
            // Submitter
            Console.WriteLine("Enter the submitter: ");
            ticket.submitter = Console.ReadLine();
            
            // Assigned
            Console.WriteLine("Enter who is assigned: ");
            ticket.assigned = Console.ReadLine();
            
            // Watching
            Console.WriteLine("Enter who is watching: ");
            ticket.watching = Console.ReadLine();
            

            
            return ticket;
        }
          public void addTicketToFile(string file, Ticket ticket) {
            
            StreamWriter sw = new StreamWriter(file, append: true);

            // write line to file
            sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", 
            ticket.ticketID, ticket.summary, ticket.status, ticket.priority, 
            ticket.submitter, ticket.assigned, ticket.watching);

            sw.Close();                     
        }
         public Ticket readTicketInformation(string line) {
            
            // convert line of data from file into array
            string[] arr = line.Split(',', '|');
            
            // make new ticket and give it data
            Ticket ticket = new Ticket();
            ticket.ticketID = arr[0];
            ticket.summary = arr[1];
            ticket.status = arr[2];
            ticket.priority = arr[3];
            ticket.submitter = arr[4];
            ticket.assigned = arr[5];
            ticket.watching = arr[6];
            return ticket;
        }
      private string calculateTicketID(string file) {
            
            // make list of ticket IDs
            List<UInt64> ticketIds = new List<UInt64>();
            
            StreamReader sr = new StreamReader(file);
    
            // skip first line
            sr.ReadLine();

            // go through file to populate list of IDs
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] arr = line.Split(',','|');
                ticketIds.Add(UInt64.Parse(arr[0]));
            }
            sr.Close();

            // find max ID value in ID list and add 1 to current ticket
            UInt64 ticketID = ticketIds.Max() + 1;
            return (ticketID.ToString()); 
        }
    }
}