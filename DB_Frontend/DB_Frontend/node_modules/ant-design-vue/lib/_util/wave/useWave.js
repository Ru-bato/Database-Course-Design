"use strict";

var _interopRequireDefault = require("@babel/runtime/helpers/interopRequireDefault");
Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.default = useWave;
var _propsUtil = require("../props-util");
var _WaveEffect = _interopRequireDefault(require("./WaveEffect"));
function useWave(instance, className, wave) {
  function showWave() {
    var _a;
    const node = (0, _propsUtil.findDOMNode)(instance);
    if (((_a = wave === null || wave === void 0 ? void 0 : wave.value) === null || _a === void 0 ? void 0 : _a.disabled) || !node) {
      return;
    }
    (0, _WaveEffect.default)(node, className.value);
  }
  return showWave;
}