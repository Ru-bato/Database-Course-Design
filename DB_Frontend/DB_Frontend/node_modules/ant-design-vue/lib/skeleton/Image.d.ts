import type { SkeletonElementProps } from './Element';
export type SkeletonImageProps = Omit<SkeletonElementProps, 'size' | 'shape' | 'active'>;
declare const SkeletonImage: import("vue").DefineComponent<Omit<{
    prefixCls: StringConstructor;
    size: import("vue").PropType<number | "default" | "small" | "large">;
    shape: import("vue").PropType<"default" | "circle" | "round" | "square">;
    active: {
        type: BooleanConstructor;
        default: any;
    };
}, "size" | "active" | "shape">, () => import("../_util/type").VueNode, unknown, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, {}, string, import("vue").PublicProps, Readonly<import("vue").ExtractPropTypes<Omit<{
    prefixCls: StringConstructor;
    size: import("vue").PropType<number | "default" | "small" | "large">;
    shape: import("vue").PropType<"default" | "circle" | "round" | "square">;
    active: {
        type: BooleanConstructor;
        default: any;
    };
}, "size" | "active" | "shape">>>, {}, {}>;
export default SkeletonImage;
