using System;
using System.IO;
namespace TicketingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Display display = new Display();

            ManageTicket manageTicket = new ManageTicket();
           string file = "Tickets.csv";
           string choice;

            do{
             display.menuChoice();
                choice = Console.ReadLine();
                if (choice == "1")
                {

            

                    if(File.Exists(file))
                    {
                         StreamReader sr = new StreamReader(file);
                         string line = sr.ReadLine();
                            while(!sr.EndOfStream)
                            {
                                Ticket ticket = new Ticket();
                                 line =sr.ReadLine();
                                 ticket = manageTicket.readTicketInformation(line);
                                 display.ticketInformation(ticket);
                            }
                            sr.Close();
                    }else
                        {
                        display.fileDoesNotExist();
                        }
                }else if (choice == "2")
                {
                    
                        // StreamWriter sw = new StreamWriter(file, append: true); 
                         string resp;
                         do{

                    
                                display.newTicket();
                                resp = Console.ReadLine().ToUpper();
                                if (resp != "Y")
                                 {
                                     break;
                                }
                                     Ticket ticket = new Ticket();
                                    ticket = manageTicket.askTicketInformation(file);
                                     manageTicket.addTicketToFile(file, ticket);
                            }while (resp == "Y");
                    
                }
            }while (choice == "1" || choice =="2");
            
        }
    }
}

    
    

