import { findDOMNode } from '../props-util';
import showWaveEffect from './WaveEffect';
export default function useWave(instance, className, wave) {
  function showWave() {
    var _a;
    const node = findDOMNode(instance);
    if (((_a = wave === null || wave === void 0 ? void 0 : wave.value) === null || _a === void 0 ? void 0 : _a.disabled) || !node) {
      return;
    }
    showWaveEffect(node, className.value);
  }
  return showWave;
}