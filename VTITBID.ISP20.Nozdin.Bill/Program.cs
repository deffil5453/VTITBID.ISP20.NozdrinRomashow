using VTITBid.ISP20.Nozdrin.Bill;

Console.ForegroundColor = ConsoleColor.Green;
int n = 3;
ListAccounts[] listAccounts = new ListAccounts[n];
ListAccounts bill = new ListAccounts();

ListAccounts.Conclusion(n, listAccounts);