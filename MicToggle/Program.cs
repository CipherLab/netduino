using System;
using System.Threading;
using System.Diagnostics;
using System.Device.Gpio; // Added for GPIO functionality

namespace MicToggle
{
    public class Program
    {
        private const int ButtonPinNumber = 7;
        private const int LedPinNumber = 2; // Assuming onboard LED is on pin 2, common for nanoFramework boards

        public static void Main()
        {
            Debug.WriteLine("Hello from nanoFramework!");

            Console.WriteLine("ESP32-S3 Button and LED Test Program Started with .NET nanoFramework!");
            Console.WriteLine($"Monitoring button on GPIO{ButtonPinNumber}");
            Console.WriteLine($"Controlling LED on GPIO{LedPinNumber}");
            Console.WriteLine("Ensure button is connected between GPIO" + ButtonPinNumber + " and GND.");
            Console.WriteLine("Using NC button setup: Pressing button (open circuit) should trigger.");


            GpioController gpioController = new GpioController();
            // For an NC button connected between the GPIO pin and GND:
            // When button NOT pressed (circuit closed to GND) -> pin reads LOW
            // When button IS pressed (circuit open) -> pin reads HIGH (due to PullUp)
            GpioPin buttonPin = gpioController.OpenPin(ButtonPinNumber, PinMode.InputPullUp);

            // Initialize LED pin as output
            GpioPin ledPin = gpioController.OpenPin(LedPinNumber, PinMode.Output);
            ledPin.Write(PinValue.Low); // Ensure LED is off initially

            bool buttonWasPressed = false; // For NC button logic with PullUp
            bool ledState = false; // false = off, true = on
            int debounceDelay = 200;

            while (true)
            {
                PinValue currentButtonState = buttonPin.Read();

                if (currentButtonState == PinValue.High && !buttonWasPressed)
                {
                    Console.WriteLine($"Button Pressed! (NC Circuit Opened on GPIO{ButtonPinNumber})");
                    buttonWasPressed = true;

                    // Toggle LED state
                    ledState = !ledState;
                    ledPin.Write(ledState ? PinValue.High : PinValue.Low);
                    Console.WriteLine($"LED is now {(ledState ? "ON" : "OFF")}");

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
        }
    }
}
