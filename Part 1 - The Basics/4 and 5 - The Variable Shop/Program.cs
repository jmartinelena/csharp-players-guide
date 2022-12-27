byte intByte = 1;
short intShort = 2;
int intInt = 100000;
long intLong = 2_000_000_000_000L; // la L es opcional
sbyte intSbyte = -120;
ushort intUshort = 60000;
uint intUint = 300000000;
ulong intUlong = 5000000000000000; // podria agregarse U o L (o ambos) al final, no importa el orden entre U y L

int intBinary = 0b00010101;
int intHexadecimal = 0xFF00FF;

char txtChar = 'a';
string txtString = "abc";

float floatFloat = 3.14f;
double floatDouble = 6.022e-23;
decimal floatDecimal = 0.00000000000000000000001m;

bool boolTrue = true;
bool boolFalse = false;

Console.WriteLine($"ints: {intByte},{intShort},{intInt},{intLong},{intSbyte},{intUshort},{intUint},{intUlong},{intBinary},{intHexadecimal}");
Console.WriteLine($"char: {txtChar} string: {txtString}");
Console.WriteLine($"floats: {floatFloat},{floatDouble},{floatDecimal}");
Console.WriteLine($"bools: {boolTrue} y {boolFalse}");
