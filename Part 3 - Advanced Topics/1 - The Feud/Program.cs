using TheFeud.IField;
using TheFeud.McDroid;

namespace TheFeud
{
    public class Program
    {
        static void Main(string[] args)
        {
            IField.Pig pig = new IField.Pig();
            Sheep sheep = new Sheep();
            McDroid.Pig pig2 = new McDroid.Pig();
            Cow cow = new Cow();
        }
    }
}