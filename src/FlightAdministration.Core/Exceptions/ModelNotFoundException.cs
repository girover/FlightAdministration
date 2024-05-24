using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAdministration.Core.Exceptions;
public class ModelNotFoundException(string message) : Exception(message) { }
