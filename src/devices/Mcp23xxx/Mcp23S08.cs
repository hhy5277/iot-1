﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Device.Gpio;
using System.Device.Spi;

namespace Iot.Device.Mcp23xxx
{
    /// <summary>
    /// Driver for the Microchip MCP23S08 8-Bit I/O Expander with Serial Interface.
    /// </summary>
    public class Mcp23s08 : Mcp23x0x
    {
        /// <summary>
        /// Initializes a new instance of the Mcp23s08 device.
        /// </summary>
        /// <param name="spiDevice">The SPI device used for communication.</param>
        /// <param name="deviceAddress">The device address for the connection on the SPI bus.</param>
        /// <param name="reset">
        /// The output pin number that is connected to the hardware reset, if any. If specified the device
        /// will start in a disabled state.
        /// </param>
        /// <param name="interrupt">The input pin number that is connected to the interrupt, if any.</param>
        /// <param name="masterController">
        /// The controller for the reset and interrupt pins. If not specified, the default controller will be used.
        /// </param>
        public Mcp23s08(SpiDevice spiDevice, int deviceAddress, int reset = -1, int interrupt = -1, IGpioController masterController = null)
            : base(CreateAdapter(spiDevice, deviceAddress), reset, interrupt, masterController)
        {
        }

        private static SpiAdapter CreateAdapter(SpiDevice spiDevice, int deviceAddress)
        {
            if (deviceAddress < 0x20 || deviceAddress > 0x23)
            {
                throw new ArgumentOutOfRangeException(nameof(deviceAddress), "The Mcp23s08 address must be between 32 (0x20) and 35 (0x23).");
            }
            return new SpiAdapter(spiDevice, deviceAddress);
        }
    }
}
