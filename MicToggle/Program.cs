using System;
using System.Threading;
using System.Diagnostics;

namespace MicToggle
{
    public class Program
    {
        private const int ButtonPinNumber = 7;

        public static void Main()
        {
            Debug.WriteLine("Hello from nanoFramework!");

            Thread.Sleep(Timeout.Infinite);

            // Browse our samples repository: https://github.com/nanoframework/samples
            // Check our documentation online: https://docs.nanoframework.net/
            // Join our lively Discord community: https://discord.gg/gCyBu8T

            /*

Console.WriteLine("ESP32-S3 Button Test Program Started with .NET nanoFramework!");
            Console.WriteLine($"Monitoring button on GPIO{ButtonPinNumber}");
            Console.WriteLine("Ensure button is connected between GPIO" + ButtonPinNumber + " and GND.");
            Console.WriteLine("Using NC button setup: Pressing button (open circuit) should trigger.");


            GpioController gpioController = new GpioController();
            // For an NC button connected between the GPIO pin and GND:
            // When button NOT pressed (circuit closed to GND) -> pin reads LOW
            // When button IS pressed (circuit open) -> pin reads HIGH (due to PullUp)
            GpioPin buttonPin = gpioController.OpenPin(ButtonPinNumber, PinMode.InputPullUp);

            bool buttonWasPressed = false; // For NC button logic with PullUp
            int debounceDelay = 200;

            while (true)
            {
                PinValue currentButtonState = buttonPin.Read();

                if (currentButtonState == PinValue.High && !buttonWasPressed)
                {
                    Console.WriteLine($"Button Pressed! (NC Circuit Opened on GPIO{ButtonPinNumber})");
                    buttonWasPressed = true;
                    Thread.Sleep(debounceDelay);
                }
                else if (currentButtonState == PinValue.Low && buttonWasPressed)
                {
                    // Optional: message when released
                    // Console.WriteLine($"Button Released (NC Circuit Closed on GPIO{ButtonPinNumber})");
                    buttonWasPressed = false;
                    Thread.Sleep(debounceDelay);
                }
                Thread.Sleep(50); // Small delay
            }

            */
        }
    }
}
