using RPC.Rpc;

var rpcClient = new RpcClient();

while (true)
{
    var num = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($" [x] Requesting fib({num})");
    var response = rpcClient.Call(num.ToString());

    Console.WriteLine(" [.] Got '{0}'", response);
}
rpcClient.Close();