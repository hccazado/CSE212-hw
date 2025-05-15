/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        var cs = new CustomerService(3);
        Console.WriteLine(cs);

        // Test Cases
        // Test 1
        // Scenario: A Queue with max_size of 3. Shouldn't accept more than 3 customers in the queue
        // Expected Result: When the user tries to add an exceding customer, "Maximum Number of Customers in Queue" 
        // message should be returned.
        // Defect(s) Found: AddNewCustomer function had a logic validation and was permitting the user to add one exciding customer
        Console.WriteLine("Test 1");
        Console.WriteLine("Adding more than 3 users");
        
        Console.WriteLine("=================");
        //for(int i=1; i< 6; i++){
        //    Console.WriteLine("Adding Customer: "+i);
        //    cs.AddNewCustomer();
        //}
        Console.WriteLine(cs); 
        Console.WriteLine("-----------------");
        
        // Test 2
        // Scenario: creating customer service with invalid value.
        // Expected Result: A customer service with default size should be created.
        // Defect(s) Found: No defects were found
        Console.WriteLine("Test 2");
        Console.WriteLine("Creating a queue with invalid value");
        var cs2 = new CustomerService(0);
        Console.WriteLine(cs2);
        Console.WriteLine("-----------------");

        Console.WriteLine("=================");

        // Test 3
        // Scenario: creating customer service with a capacity of 2, and trying to dequeue them.
        // Expected Result: The customer in queues front should be returned, when the queue is empty an error message is expected.
        // Defect(s) Found: ServeCustomer had two problems: 
        //                - Was removing (dequeuing) the customer before storing it in a variable and exhibing it
        //                - Wasn't treating an empty queue scenario, throwing an outofbounds exception.
        Console.WriteLine("Test 3");
        var cs3 = new CustomerService(2);
        cs3.AddNewCustomer();
        cs3.AddNewCustomer();
        cs3.AddNewCustomer(); //Testing queue limit size.

        //poping customers from the queue
        cs3.ServeCustomer();
        cs3.ServeCustomer();
        cs3.ServeCustomer(); //By now an error message is expected

        Console.WriteLine(cs3);
        Console.WriteLine("-----------------");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) { //previous logic permited the queue to store one more customer than the specified
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        try{
            if(_queue.Count == 0){
                Console.WriteLine("No customers in the queue.");
            }
            else{
            var customer = _queue[0];
            Console.WriteLine(customer);
            _queue.RemoveAt(0);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}