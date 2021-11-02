using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace AddressBook_Collection_Assignments
{
    public class AddressBookSystem
    {
        //declaring a List
        public List<Contacts> People = new List<Contacts>();

        //declaring a dictionary for storing unique contacts
        public Dictionary<string, List<Contacts>> dictionary = new Dictionary<string, List<Contacts>>();


        /// <summary>
        /// UC1 ==> added contact details
        /// </summary>
        public void ContactDetails()
        {
            //Created object of Contacts class
            Contacts person = new Contacts();

            Console.WriteLine(" * **Enter the Person Details***");

            Console.Write("Enter First Name: ");
            person.firstname = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            person.lastname = Console.ReadLine();

            Console.Write("Enter the Address: ");
            person.address = Console.ReadLine();

            Console.Write("Enter City name: ");
            person.city = Console.ReadLine();

            Console.Write("Enter State name: ");
            person.state = Console.ReadLine();

            Console.Write("Enter the Zip Code: ");
            person.zipcode = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Phone Number: ");
            person.phonenumber = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the Email ID: ");
            person.email = Console.ReadLine();

            //added the details of the person to the list
            People.Add(person);

            Console.WriteLine("\nSuccessfully Added the Person Details\n");
            Console.WriteLine("***************");
        }


        /// <summary>
        /// printing the details
        /// </summary>
        /// <param name="person"></param>
        public void PrintDetails(Contacts person)
        {
            Console.WriteLine("First Name: " + person.firstname);
            Console.WriteLine("Last Name: " + person.lastname);
            Console.WriteLine("Address: " + person.address);
            Console.WriteLine("City: " + person.city);
            Console.WriteLine("State: " + person.state);
            Console.WriteLine("Zip Code: " + person.zipcode);
            Console.WriteLine("Phone Number: " + person.phonenumber);
            Console.WriteLine("Email ID: " + person.email);
            Console.WriteLine("-------------------------------------------");
        }


        /// <summary>
        /// UC2 ==> Check any details present in list or not 
        /// </summary>
        public void ListAllContacts()
        {
            if (People.Count == 0)
            {
                Console.WriteLine("Your address book is empty. Press any key to continue.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Here are the current people in your address book:\n");
            foreach (var person in People)
            {
                PrintDetails(person);
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }


        /// <summary>
        /// UC3 ==> update the contact details which exist in the list
        /// </summary>
        public void UpdateExistingContact()
        {
            Console.WriteLine("Press 1 If you want to edit any Contact in the Address Book");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Enter the First Name of the Person U want to update");
                    string firstname = Console.ReadLine();
                    Contacts person = People.Find(x => x.firstname.ToLower() == firstname.ToLower());
                    if (person == null)
                    {
                        Console.WriteLine("That person U entered is not found");
                    }

                    Console.WriteLine("Are you sure you want to edit the person details from your address book? Enter --> (Y/N)");
                    PrintDetails(person);
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        Console.WriteLine("Press 1 if u want to edit the LastName");
                        Console.WriteLine("Press 2 if u want to edit the Address");
                        Console.WriteLine("Press 3 if u want to edit the City");
                        Console.WriteLine("Press 4 if u want to edit the State");
                        Console.WriteLine("Press 5 if u want to edit the Zip Code");
                        Console.WriteLine("Press 6 if u want to edit the Phone Number");
                        Console.WriteLine("Press 7 if u want to edit the Email Id");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Enter New LastName; ");
                                person.lastname = Console.ReadLine();
                                People.Add(person);
                                Console.WriteLine("Last Name: " + person.lastname);
                                break;
                            case 2:
                                Console.WriteLine("Enter New Address; ");
                                person.address = Console.ReadLine();
                                People.Add(person);
                                Console.WriteLine("Address: " + person.address);
                                break;
                            case 3:
                                Console.WriteLine("Enter New City: ");
                                person.city = Console.ReadLine();
                                People.Add(person);
                                Console.WriteLine("City: " + person.city);
                                break;
                            case 4:
                                Console.WriteLine("Enter New State: ");
                                person.state = Console.ReadLine();
                                People.Add(person);
                                Console.WriteLine("MobileNumber: " + person.state);
                                break;
                            case 5:
                                Console.WriteLine("Enter New ZipCode: ");
                                person.zipcode = Convert.ToInt32(Console.ReadLine());
                                People.Add(person);
                                Console.WriteLine("ZipCode: " + person.zipcode);
                                break;
                            case 6:
                                Console.WriteLine("Enter New PhoneNumber: ");
                                person.phonenumber = Convert.ToDouble(Console.ReadLine());
                                People.Add(person);
                                Console.WriteLine("PhoneNumber: " + person.phonenumber);
                                break;
                            case 7:
                                Console.WriteLine("Enter New Email ID: ");
                                person.email = Console.ReadLine();
                                People.Add(person);
                                Console.WriteLine("Email Id: " + person.email);
                                break;

                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }
                    }
                    if (Console.ReadKey().Key == ConsoleKey.N)
                    {
                        Console.WriteLine("OKK. Press any key to continue.");
                    }
                    ListAllContacts();
                    break;
                default:
                    Console.WriteLine("Thanku!!!");
                    break;
            }
        }

        /// <summary>
        /// UC4 ==> remove a person by searching his name
        /// </summary>
        public void RemovePerson()
        {
            Console.WriteLine("Enter the first name of the person you would like to remove:");
            string firstname = Console.ReadLine();
            //Contacts findperson = people.Find(x => x.firstname.ToLower() == firstname.ToLower());
            Contacts findperson = People.FirstOrDefault(x => x.firstname.ToLower() == firstname.ToLower());
            if (findperson == null)
            {
                Console.WriteLine("That person could not be found");
            }
            else
            {
                Console.WriteLine("Person with the Given name exists");
                Console.WriteLine("Are you sure you want to remove this person from your address book? (Y/N)");
                PrintDetails(findperson);
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {

                    People.Remove(findperson);
                    Console.WriteLine("Person removed. Press any key to continue.");
                    Console.ReadKey();
                    return;
                }
                ListAllContacts();
                if (Console.ReadKey().Key == ConsoleKey.N)
                {
                    Console.WriteLine("OKK. Press any key to continue.");
                }
            }
        }

        /// <summary>
        /// UC5 ==> adding multiple contacts to the list
        /// </summary>
        public void AddMultipleContact()
        {
            Console.Write("How many contacts want to add :");
            int num = Convert.ToInt32(Console.ReadLine());
            while (num > 0)
            {
                ContactDetails();
                ListAllContacts();
                num--;
            }
        }


        /// <summary>
        /// UC6 ==> adding multiple unique contacts and maintaining dictionary
        /// </summary>
        public void AddMultiplePerson_With_UniqueAddress()
        {
            Console.Write("How many contacts u want to add :");
            int num = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= num; i++)
            {
                while (i <= num)
                {
                    for (int j = 0; j < num; j++)
                    {
                        Console.Write("Enter the First Name: ");
                        string fname = Console.ReadLine();
                        if (People[j].firstname.Equals(fname))
                        {
                            Console.WriteLine("Name already exists\n");
                            Console.ReadKey();
                            Console.WriteLine("\nEnter a New name and Add the details");
                            ContactDetails();
                            ListAllContacts();
                        }
                        else
                        {
                            ContactDetails();
                            ListAllContacts();
                        }
                    }
                    i++;
                    break;
                }
            }
        }


        /// <summary>
        /// UC7 ==> ensure there is no duplicate Entry of the same person in a particular Address Book
        /// </summary>
        //AddressBook with Unique Names
        public void AddUniqueAddressBook()
        {
            bool exit = false;
            while (exit != true)
            {
                Console.Write("----------------------------------------------\nEnter the Name of Address Book :");
                string uniqueName = Console.ReadLine();

                if (dictionary.ContainsKey(uniqueName))
                {
                    Console.WriteLine("{0} Address Book Already Exists. Try Different one..", uniqueName);
                    Console.WriteLine("Press any key to Continue ..");
                    Console.ReadKey();
                }
                else
                {
                    dictionary.Add(uniqueName, People);
                    Console.WriteLine("Address Book Saved.");
                    Console.WriteLine("Please Wait..........\nYou Will be Redirected to Your Address Book to Enter Your Details.....");
                    Thread.Sleep(5000);
                    exit = true;
                    Console.Clear();
                }
            }
        }


        /// <summary>
        /// Check any address book present in the dictionary or not
        /// </summary>
        public void DisplayAddressBookNames()
        {
            if (dictionary.Count == 0)
            {
                Console.WriteLine("Sorry!! Address Book is Empty. Press any key to continue.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Here are the Existing Address Book in Your System: ");
            foreach (var dictNames in dictionary)
            {
                Console.WriteLine(dictNames.Key);
            }
            Console.WriteLine("Press any key to comtinue..");
            Console.ReadKey();
        }


        /// <summary>
        /// UC8 ==> search Person in a City or State across the multiple AddressBook
        /// </summary>
        public void Search_Person_By_CityOrState()
        {
            Console.Write("Please enter 1  for City 2 for State : ");
            int options = Convert.ToInt32(Console.ReadLine());
            switch (options)
            {
                case 1:
                    Console.Write("Enter City Name : ");
                    string city = Console.ReadLine();
                    foreach (Contacts person in People.FindAll(e => e.city.ToLower() == city.ToLower()))
                    {
                        PrintDetails(person);
                    }
                    break;

                case 2:
                    Console.Write("Enter State Name :");
                    string state = Console.ReadLine();
                    foreach (Contacts person in People.FindAll(e => e.state.ToLower() == state.ToLower()))
                    {
                        PrintDetails(person);
                    }
                    break;
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }


        /// <summary>
        /// UC9 ==> Ability to view Persons by City or State
        /// </summary>
        public void View_Person_By_CityorState()
        {
            Console.Write("Please enter 1  for City 2 for State :");
            int options = Convert.ToInt32(Console.ReadLine());
            switch (options)
            {
                case 1:
                    Console.Write("Please enter city Name :");
                    string city = Console.ReadLine();
                    List<Contacts> cityList = new List<Contacts>();
                    foreach (Contacts person in People.FindAll(e => e.city.ToLower() == city.ToLower()))
                    {
                        cityList.Add(person);
                    }
                    dictionary.Add(city, cityList);
                    foreach (var element in dictionary[city])
                    {
                        PrintDetails(element);
                    }
                    break;

                case 2:
                    Console.Write("Please enter State Name :");
                    string state = Console.ReadLine();
                    List<Contacts> stateList = new List<Contacts>();
                    foreach (Contacts person in People.FindAll(e => e.state.ToLower() == state.ToLower()))
                    {
                        stateList.Add(person);
                    }
                    dictionary.Add(state, stateList);
                    foreach (var element in dictionary[state])
                    {
                        PrintDetails(element);
                    }
                    break;
            }
            Console.WriteLine("Press any key to Continue ..");
            Console.ReadKey();
        }


        /// <summary>
        /// UC10 ==> Ability to get number of contact persons i.e. count by City or State
        /// </summary>
        public void Count_Contacts_By_CitiesOrStates()
        {
            Console.Write("Please enter 1  for City 2 for State :");
            int options = Convert.ToInt32(Console.ReadLine());
            switch (options)
            {
                case 1:
                    Console.Write("Please enter city Name :");
                    string city = Console.ReadLine();
                    List<Contacts> cityList = new List<Contacts>();
                    foreach (Contacts person in People.FindAll(e => e.city.ToLower() == city.ToLower()))
                    {
                        cityList.Add(person);
                    }
                    dictionary.Add(city, cityList);
                    foreach (var element in dictionary[city])
                    {
                        PrintDetails(element);
                    }
                    int cityCount = dictionary[city].Count();
                    Console.WriteLine("Total :{0}", cityCount);
                    Console.WriteLine("Press any key to Continue ..");
                    Console.ReadKey();
                    break;

                case 2:
                    Console.Write("Please Enter the State Name :");
                    string state = Console.ReadLine();
                    List<Contacts> stateList = new List<Contacts>();
                    foreach (Contacts person in People.FindAll(e => e.city.ToLower() == state.ToLower()))
                    {
                        stateList.Add(person);
                    }
                    dictionary.Add(state, stateList);
                    foreach (var element in dictionary[state])
                    {
                        PrintDetails(element);
                    }
                    int stateCount = dictionary[state].Count();
                    Console.WriteLine("Total :{0}", stateCount);
                    Console.WriteLine("Press any key to Continue ..");
                    Console.ReadKey();
                    break;
            }
        }


        /// <summary>
        /// UC11 ==> Sort Contacts in alphabetically by Person’s name
        /// </summary>
        public void Sort_Contact_by_PersonName()
        {
            foreach (var names in People.OrderBy(e => e.firstname).ToList())
            {
                if (People.Contains(names))
                {
                    PrintDetails(names);
                }
                else
                {
                    Console.WriteLine("Contact does not Exist..");
                }
            }
            Console.WriteLine("Press any key to Continue ..");
            Console.ReadKey();
            Console.Clear();
        }


        /// <summary>
        /// UC12 ==> Sort Contacts by City, State or Zip
        /// </summary>
        public void Sort_Contacts_By_City_State_Or_Zip()
        {
            Console.Write("Please enter 1  for City, 2 for State, 3 for Zip: ");
            int options = Convert.ToInt32(Console.ReadLine());
            switch (options)
            {
                case 1:
                    foreach (var data in People.OrderBy(x => x.city).ToList())
                    {
                        if (People.Contains(data))
                        {
                            PrintDetails(data);
                        }
                        else
                        {
                            Console.WriteLine("contact does not exists");
                        }
                    }
                    break;
                case 2:
                    foreach (var data in People.OrderBy(x => x.state).ToList())
                    {
                        if (People.Contains(data))
                        {
                            PrintDetails(data);
                        }
                        else
                        {
                            Console.WriteLine("contact does not exists");
                        }
                    }
                    break;
                case 3:
                    foreach (var data in People.OrderBy(x => x.zipcode).ToList())
                    {
                        if (People.Contains(data))
                        {
                            PrintDetails(data);
                        }
                        else
                        {
                            Console.WriteLine("contact does not exists");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Choose Valid Option!!");
                    break;
            }
        }


        /// <summary>
        /// UC13 ==> Read or Write the Address Book with Persons Contact into a File using File IO
        /// </summary>
        public void Save_Contacts_To_TextFile()
        {
            //path for the text file to read or write the contacts
            string Path = @"C:\Users\Afiyat Khan\source\repos\AddressBook_Collection_Assignment\AddressBook_Collection_Assignment\PersonContacts.txt";

            using TextWriter tw = new StreamWriter(Path);
            foreach (var contacts in People)
            {
                tw.WriteLine(contacts.firstname.ToString() + " " + contacts.lastname.ToString() + " " + contacts.address.ToString() + " " + contacts.city.ToString() + " " + contacts.state.ToString() + " " + contacts.phonenumber.ToString() + " " + contacts.zipcode.ToString() + " " + contacts.email.ToString());
            }
            Console.WriteLine("\nDetails Added Successfully to the TextFile\n");
        }


        /// <summary>
        /// UC14 ==> Read or Write the Address Book with Persons Contact into a CSV File
        /// </summary>
        public void Save_Contacts_To_CSVFile()
        {

            //path for the csv file to read or write the contacts
            string CsvFilePath = @"C:\Users\Afiyat Khan\source\repos\AddressBook_Collection_Assignment\AddressBook_Collection_Assignment\PersonContacts.csv";

            using TextWriter textwriter = new StreamWriter(CsvFilePath);
            using (var csvExport = new CsvWriter(textwriter, CultureInfo.InvariantCulture))
            {
                csvExport.WriteRecords(People);
            }
            Console.WriteLine("\nDetails Added Successfully to the CSV File\n");
        }


        /// <summary>
        /// UC15 ==> Read or Write the Address Book with Person's Contact as JSON File
        /// </summary>
        public void Save_Contacts_To_JsonFile()
        {
            string jsonFilePath = @"C:\Users\Afiyat Khan\source\repos\AddressBook_Collection_Assignment\AddressBook_Collection_Assignment\PersonContacts.json";

            JsonSerializer jsonSerializer = new JsonSerializer();
            StreamWriter sw = new StreamWriter(jsonFilePath);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonSerializer.Serialize(jsonWriter, People);
            }
            Console.WriteLine("\nDetails Added Successfully to the Json File\n");
        }


        /// <summary>
        /// Choose options for adding the details in a address book
        /// </summary>
        public void ChooseOption()
        {
            Console.WriteLine("\n**********\nWELCOME TO YOUR ADDRESS BOOK\n**********\n");
            Console.WriteLine("\n****************\nPlease Choose Any Option And Add The Details\n****************\n");
            bool exit = false;
            while (exit != true)
            {
                Console.WriteLine("Choose a number: " + "\n1 :Create Contact\n" + "2 :List All People Present in the List\n" + "3 :Edit Existing Contact\n" + "4 :Removing Contact\n" + "5 :Adding Multiple Contact\n" + "6 :Adding Multiple Unique Contact\n" + "7 :Display Unique Contacts Address Book\n" + "8 :Search Multiple Person Names in City or State\n" + "9 :Display Contacts By City or State\n" + "10 :Count Contacts By City or State\n" + "11 :Sort Contacts By Person Name\n" + "12 :Sort Contacts by City, State or Zip\n" + "13 :Save Contacts To TextFile\n" + "14 :Save Contacts To CSVFile\n" + "15 :Save Contacts To JsonFile\n" + "16 :Exit From the Address Book\n");
                int options = Convert.ToInt32(Console.ReadLine());
                switch (options)
                {
                    case 1:
                        ContactDetails();
                        break;
                    case 2:
                        ListAllContacts();
                        break;
                    case 3:
                        UpdateExistingContact();
                        break;
                    case 4:
                        RemovePerson();
                        break;
                    case 5:
                        AddMultipleContact();
                        break;
                    case 6:
                        ContactDetails();
                        AddMultiplePerson_With_UniqueAddress();
                        break;
                    case 7:
                        DisplayAddressBookNames();
                        break;
                    case 8:
                        Search_Person_By_CityOrState();
                        break;
                    case 9:
                        View_Person_By_CityorState();
                        break;
                    case 10:
                        Count_Contacts_By_CitiesOrStates();
                        break;
                    case 11:
                        Sort_Contact_by_PersonName();
                        break;
                    case 12:
                        Sort_Contacts_By_City_State_Or_Zip();
                        break;
                    case 13:
                        Save_Contacts_To_TextFile();
                        break;
                    case 14:
                        Save_Contacts_To_CSVFile();
                        break;
                    case 15:
                        Save_Contacts_To_JsonFile();
                        break;
                    case 16:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Choose Valid Option!!");
                        break;
                }
                Console.Clear();
            }
        }
    }
}