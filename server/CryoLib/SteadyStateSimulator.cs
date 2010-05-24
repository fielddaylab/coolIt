using System;
using System.Collections.Generic;
using System.Text;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;
using SteadyStateSim;

using log4net;

namespace CryoLib {
	public class SteadyStateSimulator {
		protected SteadyStateSim.SteadyStateSim matlabSim;

        private static readonly log4net.ILog _logger
        = log4net.LogManager.GetLogger(
                System.Reflection.MethodBase.GetCurrentMethod()
                 .DeclaringType);

		public SteadyStateSimulator() {
			try {
                _logger.Debug("Loading SteadyStateSim.SteadyStateSim");
				matlabSim = new SteadyStateSim.SteadyStateSim();
                _logger.Debug("SteadyStateSim loading successful");
			} catch (Exception ex) {
                _logger.Debug("Exception thrown loading SteadyStateSim.SteadyStateSim");
                _logger.ErrorFormat("Exception {0} Inner Exception {1}", ex.Message, ex.InnerException);
				throw ex;
			}
		}

		public double strutLength( double targetTemp, double crossSection, Material material, CoolerModel cooler ) {
			MWNumericArray targetTempData = new MWNumericArray( targetTemp );
			MWNumericArray crossSectionData = new MWNumericArray( crossSection );
			MWNumericArray materialData = material.getData("PM");
			MWNumericArray coolerData = cooler.getData("CPM");
			MWNumericArray strutLength = (MWNumericArray)matlabSim.strutlength(
				targetTempData, crossSectionData, materialData, coolerData);
			return strutLength.ToScalarDouble();
		}

		public double strutLength(double targetTemp, double crossSection, Material material, CoolerModel cooler, double powerFactor) {
			double[,] data = cooler.getDataNative("CPM");
			for (int i = 0; i < data.GetLength(0); i++) {
				data[i, 0] = 300.0 - (300.0 - data[i, 0]) * powerFactor;
				data[i, 1] *= powerFactor;
			}
			MWNumericArray targetTempData = new MWNumericArray( targetTemp );
			MWNumericArray crossSectionData = new MWNumericArray( crossSection );
			MWNumericArray materialData = material.getData("PM");
			MWNumericArray coolerData = (MWNumericArray)data;
			MWNumericArray strutLength = (MWNumericArray)matlabSim.strutlength(
				targetTempData, crossSectionData, materialData, coolerData);
			double answer = strutLength.ToScalarDouble();
			return answer;

		}

		public double simulate(double length, double crossSection, Material material, CoolerModel cooler) {
			try {
				MWNumericArray lengthData = new MWNumericArray(length);
				MWNumericArray crossSectionData = new MWNumericArray(crossSection);
				MWNumericArray materialData = material.getData("PM");
				MWNumericArray coolerData = cooler.getData("CPM");
				MWNumericArray ssTemp = (MWNumericArray)matlabSim.steadystatetemperature(
					lengthData, crossSectionData, materialData, coolerData);
				return ssTemp.ToScalarDouble();
			} catch (Exception ex) {
				throw new ArgumentException("Bad arguments to simulate method", ex);
			}
		}

		public double simulate(double length, double crossSection, Material material, CoolerModel cooler, double powerFactor) {
			double[,] data = cooler.getDataNative("CPM");
			for (int i = 0; i < data.GetLength(0); i++) {
				data[i, 0] = 300.0 - (300.0 - data[i, 0]) * powerFactor;
				data[i, 1] *= powerFactor;
			}
			MWNumericArray coolerData = (MWNumericArray)data;
			MWNumericArray materialData = material.getData("PM");

			// We assume that if the MATLAB code generates an exception or returns NaN, it's becuase the parameters
			// imply a system which is infeasible.  That might mean that the steady state temperature would be below
			// the lowest conductivity data point for the material.
			try {
				MWNumericArray ssTemp = (MWNumericArray)matlabSim.steadystatetemperature(length, crossSection, materialData, coolerData);
				double answer = ssTemp.ToScalarDouble();
				if (Double.IsNaN(answer)) {
					throw new ArgumentException("Bad arguments to simulate method");
				} else {
					return answer;
				}
			} catch (Exception ex) {
				throw new ArgumentException("Bad arguments to simulate method", ex);
			}
		}


	}
}
