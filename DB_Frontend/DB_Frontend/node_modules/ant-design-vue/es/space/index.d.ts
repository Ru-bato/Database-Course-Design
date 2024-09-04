import type { PropType, ExtractPropTypes, Plugin } from 'vue';
import type { SizeType } from '../config-provider';
import type { CustomSlotsType } from '../_util/type';
import Compact from './Compact';
export type SpaceSize = SizeType | number;
export declare const spaceProps: () => {
    prefixCls: StringConstructor;
    size: {
        type: PropType<SpaceSize | [SpaceSize, SpaceSize]>;
    };
    direction: import("vue-types").VueTypeDef<string> & {
        default: string;
    };
    align: import("vue-types").VueTypeDef<string>;
    wrap: {
        type: BooleanConstructor;
        default: boolean;
    };
};
export type SpaceProps = Partial<ExtractPropTypes<ReturnType<typeof spaceProps>>>;
export { Compact };
declare const _default: {
    new (...args: any[]): import("vue").CreateComponentPublicInstance<Readonly<ExtractPropTypes<{
        prefixCls: StringConstructor;
        size: {
            type: PropType<SpaceSize | [SpaceSize, SpaceSize]>;
        };
        direction: import("vue-types").VueTypeDef<string> & {
            default: string;
        };
        align: import("vue-types").VueTypeDef<string>;
        wrap: {
            type: BooleanConstructor;
            default: boolean;
        };
    }>>, () => import("vue/jsx-runtime").JSX.Element, unknown, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, {}, import("vue").VNodeProps & import("vue").AllowedComponentProps & import("vue").ComponentCustomProps & Readonly<ExtractPropTypes<{
        prefixCls: StringConstructor;
        size: {
            type: PropType<SpaceSize | [SpaceSize, SpaceSize]>;
        };
        direction: import("vue-types").VueTypeDef<string> & {
            default: string;
        };
        align: import("vue-types").VueTypeDef<string>;
        wrap: {
            type: BooleanConstructor;
            default: boolean;
        };
    }>>, {
        direction: string;
        wrap: boolean;
    }, true, {}, CustomSlotsType<{
        split?: any;
        default?: any;
    }>, {
        P: {};
        B: {};
        D: {};
        C: {};
        M: {};
        Defaults: {};
    }, Readonly<ExtractPropTypes<{
        prefixCls: StringConstructor;
        size: {
            type: PropType<SpaceSize | [SpaceSize, SpaceSize]>;
        };
        direction: import("vue-types").VueTypeDef<string> & {
            default: string;
        };
        align: import("vue-types").VueTypeDef<string>;
        wrap: {
            type: BooleanConstructor;
            default: boolean;
        };
    }>>, () => import("vue/jsx-runtime").JSX.Element, {}, {}, {}, {
        direction: string;
        wrap: boolean;
    }>;
    __isFragment?: never;
    __isTeleport?: never;
    __isSuspense?: never;
} & import("vue").ComponentOptionsBase<Readonly<ExtractPropTypes<{
    prefixCls: StringConstructor;
    size: {
        type: PropType<SpaceSize | [SpaceSize, SpaceSize]>;
    };
    direction: import("vue-types").VueTypeDef<string> & {
        default: string;
    };
    align: import("vue-types").VueTypeDef<string>;
    wrap: {
        type: BooleanConstructor;
        default: boolean;
    };
}>>, () => import("vue/jsx-runtime").JSX.Element, unknown, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, {}, string, {
    direction: string;
    wrap: boolean;
}, {}, string, CustomSlotsType<{
    split?: any;
    default?: any;
}>> & import("vue").VNodeProps & import("vue").AllowedComponentProps & import("vue").ComponentCustomProps & Plugin<any[]> & {
    readonly Compact: typeof Compact;
};
export default _default;
