import type { CSSProperties, ExtractPropTypes } from 'vue';
import type { VueNode } from '../_util/type';
export declare const emptyProps: () => {
    prefixCls: StringConstructor;
    imageStyle: {
        type: import("vue").PropType<CSSProperties>;
        default: CSSProperties;
    };
    image: {
        default: VueNode;
        type: import("vue").PropType<VueNode>;
    };
    description: {
        default: VueNode;
        type: import("vue").PropType<VueNode>;
    };
};
export type EmptyProps = Partial<ExtractPropTypes<ReturnType<typeof emptyProps>>>;
declare const _default: {
    new (...args: any[]): import("vue").CreateComponentPublicInstance<Readonly<ExtractPropTypes<{
        prefixCls: StringConstructor;
        imageStyle: {
            type: import("vue").PropType<CSSProperties>;
            default: CSSProperties;
        };
        image: {
            default: VueNode;
            type: import("vue").PropType<VueNode>;
        };
        description: {
            default: VueNode;
            type: import("vue").PropType<VueNode>;
        };
    }>>, () => VueNode, unknown, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, {}, import("vue").VNodeProps & import("vue").AllowedComponentProps & import("vue").ComponentCustomProps & Readonly<ExtractPropTypes<{
        prefixCls: StringConstructor;
        imageStyle: {
            type: import("vue").PropType<CSSProperties>;
            default: CSSProperties;
        };
        image: {
            default: VueNode;
            type: import("vue").PropType<VueNode>;
        };
        description: {
            default: VueNode;
            type: import("vue").PropType<VueNode>;
        };
    }>>, {
        image: VueNode;
        description: VueNode;
        imageStyle: CSSProperties;
    }, true, {}, {}, {
        P: {};
        B: {};
        D: {};
        C: {};
        M: {};
        Defaults: {};
    }, Readonly<ExtractPropTypes<{
        prefixCls: StringConstructor;
        imageStyle: {
            type: import("vue").PropType<CSSProperties>;
            default: CSSProperties;
        };
        image: {
            default: VueNode;
            type: import("vue").PropType<VueNode>;
        };
        description: {
            default: VueNode;
            type: import("vue").PropType<VueNode>;
        };
    }>>, () => VueNode, {}, {}, {}, {
        image: VueNode;
        description: VueNode;
        imageStyle: CSSProperties;
    }>;
    __isFragment?: never;
    __isTeleport?: never;
    __isSuspense?: never;
} & import("vue").ComponentOptionsBase<Readonly<ExtractPropTypes<{
    prefixCls: StringConstructor;
    imageStyle: {
        type: import("vue").PropType<CSSProperties>;
        default: CSSProperties;
    };
    image: {
        default: VueNode;
        type: import("vue").PropType<VueNode>;
    };
    description: {
        default: VueNode;
        type: import("vue").PropType<VueNode>;
    };
}>>, () => VueNode, unknown, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, {}, string, {
    image: VueNode;
    description: VueNode;
    imageStyle: CSSProperties;
}, {}, string, {}> & import("vue").VNodeProps & import("vue").AllowedComponentProps & import("vue").ComponentCustomProps & import("vue").Plugin<any[]>;
export default _default;
