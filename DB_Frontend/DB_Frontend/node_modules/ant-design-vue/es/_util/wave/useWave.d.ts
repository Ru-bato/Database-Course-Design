import type { ComponentInternalInstance, ComputedRef, Ref } from 'vue';
export default function useWave(instance: ComponentInternalInstance | null, className: Ref<string>, wave?: ComputedRef<{
    disabled?: boolean;
}>): VoidFunction;
