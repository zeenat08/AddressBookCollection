using System;

namespace AddressBook_Collection_Assignments
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBookSystem addressBook = new AddressBookSystem();

            Console.WriteLine("\n*************\nWELCOME TO ADDRESS BOOK PROGRAM\n*************\n\n");

            bool isexit = false;
            while (isexit != true)
            {
                Console.WriteLine("If u Want to add a New Address Book Press ==> 1\n" + "If u want to see the Address Book exist in your system press ==> 2\n" + "If u Want to Exit Press ==> 3\n");
                Console.Write("Enter Your Choice: ");
                int response = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (response)
                {
                    case 1:
                        addressBook.AddUniqueAddressBook();
                        addressBook.ChooseOption();
                        Console.Clear();
                        break;
                    case 2:
                        addressBook.DisplayAddressBookNames();
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("***\nThanku!\n***");
                        isexit = true;
                        break;
                }
            }
        }
    }
}