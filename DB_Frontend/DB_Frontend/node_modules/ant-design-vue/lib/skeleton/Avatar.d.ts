import type { ExtractPropTypes, PropType } from 'vue';
export declare const avatarProps: () => {
    shape: PropType<"circle" | "square">;
    prefixCls: StringConstructor;
    size: PropType<number | "default" | "small" | "large">;
    active: {
        type: BooleanConstructor;
        default: any;
    };
};
export type SkeletonAvatarProps = Partial<ExtractPropTypes<ReturnType<typeof avatarProps>>>;
declare const SkeletonAvatar: import("vue").DefineComponent<{
    shape: PropType<"circle" | "square">;
    prefixCls: StringConstructor;
    size: PropType<number | "default" | "small" | "large">;
    active: {
        type: BooleanConstructor;
        default: any;
    };
}, () => import("../_util/type").VueNode, unknown, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, {}, string, import("vue").PublicProps, Readonly<ExtractPropTypes<{
    shape: PropType<"circle" | "square">;
    prefixCls: StringConstructor;
    size: PropType<number | "default" | "small" | "large">;
    active: {
        type: BooleanConstructor;
        default: any;
    };
}>>, {
    active: boolean;
}, {}>;
export default SkeletonAvatar;
