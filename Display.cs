using System;
using System.IO;
namespace TicketingSystem
{
    public class Display
    {
        public void menuChoice(){
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
        }
        public void fileDoesNotExist()
        {
            Console.WriteLine("The file does not exsist. ");
        }
        public void newTicket()
        {
            Console.WriteLine("Would you like to create a new ticket? (Y/N): ");
        }
        public void ticketInformation(Ticket ticket)
        {
            Console.WriteLine("Ticket ID: {0}\nSummary: {1}\nStatus: {2}\nPriority: {3}\nSubmitter: {4}\nAssigned: {5}\nWatching: {6}\n",ticket.ticketID, ticket.summary, ticket.status, ticket.priority, 
                ticket.submitter, ticket.assigned, ticket.watching);
        }
    }
}