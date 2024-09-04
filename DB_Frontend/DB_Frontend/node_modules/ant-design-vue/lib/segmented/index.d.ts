import type { SegmentedProps } from './src';
declare const _default: {
    new (...args: any[]): import("vue").CreateComponentPublicInstance<Readonly<import("vue").ExtractPropTypes<{
        prefixCls: StringConstructor;
        options: {
            type: import("vue").PropType<(string | number | import("./src/segmented").SegmentedOption)[]>;
            default: (string | number | import("./src/segmented").SegmentedOption)[];
        };
        block: {
            type: BooleanConstructor;
            default: boolean;
        };
        disabled: {
            type: BooleanConstructor;
            default: boolean;
        };
        size: {
            type: import("vue").PropType<import("./src/segmented").segmentedSize>;
            default: import("./src/segmented").segmentedSize;
        };
        value: {
            required: boolean;
            type: import("vue").PropType<import("./src/segmented").SegmentedValue>;
            default: import("./src/segmented").SegmentedValue;
        };
        motionName: StringConstructor;
        onChange: {
            type: import("vue").PropType<(val: import("./src/segmented").SegmentedValue) => void>;
            default: (val: import("./src/segmented").SegmentedValue) => void;
        };
        'onUpdate:value': {
            type: import("vue").PropType<(val: import("./src/segmented").SegmentedValue) => void>;
            default: (val: import("./src/segmented").SegmentedValue) => void;
        };
    }>>, () => import("../_util/type").VueNode, unknown, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, {}, import("vue").VNodeProps & import("vue").AllowedComponentProps & import("vue").ComponentCustomProps & Readonly<import("vue").ExtractPropTypes<{
        prefixCls: StringConstructor;
        options: {
            type: import("vue").PropType<(string | number | import("./src/segmented").SegmentedOption)[]>;
            default: (string | number | import("./src/segmented").SegmentedOption)[];
        };
        block: {
            type: BooleanConstructor;
            default: boolean;
        };
        disabled: {
            type: BooleanConstructor;
            default: boolean;
        };
        size: {
            type: import("vue").PropType<import("./src/segmented").segmentedSize>;
            default: import("./src/segmented").segmentedSize;
        };
        value: {
            required: boolean;
            type: import("vue").PropType<import("./src/segmented").SegmentedValue>;
            default: import("./src/segmented").SegmentedValue;
        };
        motionName: StringConstructor;
        onChange: {
            type: import("vue").PropType<(val: import("./src/segmented").SegmentedValue) => void>;
            default: (val: import("./src/segmented").SegmentedValue) => void;
        };
        'onUpdate:value': {
            type: import("vue").PropType<(val: import("./src/segmented").SegmentedValue) => void>;
            default: (val: import("./src/segmented").SegmentedValue) => void;
        };
    }>>, {
        size: import("./src/segmented").segmentedSize;
        value: import("./src/segmented").SegmentedValue;
        onChange: (val: import("./src/segmented").SegmentedValue) => void;
        block: boolean;
        disabled: boolean;
        'onUpdate:value': (val: import("./src/segmented").SegmentedValue) => void;
        options: (string | number | import("./src/segmented").SegmentedOption)[];
    }, true, {}, import("../_util/type").CustomSlotsType<{
        label: import("./src/segmented").SegmentedBaseOption;
    }>, {
        P: {};
        B: {};
        D: {};
        C: {};
        M: {};
        Defaults: {};
    }, Readonly<import("vue").ExtractPropTypes<{
        prefixCls: StringConstructor;
        options: {
            type: import("vue").PropType<(string | number | import("./src/segmented").SegmentedOption)[]>;
            default: (string | number | import("./src/segmented").SegmentedOption)[];
        };
        block: {
            type: BooleanConstructor;
            default: boolean;
        };
        disabled: {
            type: BooleanConstructor;
            default: boolean;
        };
        size: {
            type: import("vue").PropType<import("./src/segmented").segmentedSize>;
            default: import("./src/segmented").segmentedSize;
        };
        value: {
            required: boolean;
            type: import("vue").PropType<import("./src/segmented").SegmentedValue>;
            default: import("./src/segmented").SegmentedValue;
        };
        motionName: StringConstructor;
        onChange: {
            type: import("vue").PropType<(val: import("./src/segmented").SegmentedValue) => void>;
            default: (val: import("./src/segmented").SegmentedValue) => void;
        };
        'onUpdate:value': {
            type: import("vue").PropType<(val: import("./src/segmented").SegmentedValue) => void>;
            default: (val: import("./src/segmented").SegmentedValue) => void;
        };
    }>>, () => import("../_util/type").VueNode, {}, {}, {}, {
        size: import("./src/segmented").segmentedSize;
        value: import("./src/segmented").SegmentedValue;
        onChange: (val: import("./src/segmented").SegmentedValue) => void;
        block: boolean;
        disabled: boolean;
        'onUpdate:value': (val: import("./src/segmented").SegmentedValue) => void;
        options: (string | number | import("./src/segmented").SegmentedOption)[];
    }>;
    __isFragment?: never;
    __isTeleport?: never;
    __isSuspense?: never;
} & import("vue").ComponentOptionsBase<Readonly<import("vue").ExtractPropTypes<{
    prefixCls: StringConstructor;
    options: {
        type: import("vue").PropType<(string | number | import("./src/segmented").SegmentedOption)[]>;
        default: (string | number | import("./src/segmented").SegmentedOption)[];
    };
    block: {
        type: BooleanConstructor;
        default: boolean;
    };
    disabled: {
        type: BooleanConstructor;
        default: boolean;
    };
    size: {
        type: import("vue").PropType<import("./src/segmented").segmentedSize>;
        default: import("./src/segmented").segmentedSize;
    };
    value: {
        required: boolean;
        type: import("vue").PropType<import("./src/segmented").SegmentedValue>;
        default: import("./src/segmented").SegmentedValue;
    };
    motionName: StringConstructor;
    onChange: {
        type: import("vue").PropType<(val: import("./src/segmented").SegmentedValue) => void>;
        default: (val: import("./src/segmented").SegmentedValue) => void;
    };
    'onUpdate:value': {
        type: import("vue").PropType<(val: import("./src/segmented").SegmentedValue) => void>;
        default: (val: import("./src/segmented").SegmentedValue) => void;
    };
}>>, () => import("../_util/type").VueNode, unknown, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, {}, string, {
    size: import("./src/segmented").segmentedSize;
    value: import("./src/segmented").SegmentedValue;
    onChange: (val: import("./src/segmented").SegmentedValue) => void;
    block: boolean;
    disabled: boolean;
    'onUpdate:value': (val: import("./src/segmented").SegmentedValue) => void;
    options: (string | number | import("./src/segmented").SegmentedOption)[];
}, {}, string, import("../_util/type").CustomSlotsType<{
    label: import("./src/segmented").SegmentedBaseOption;
}>> & import("vue").VNodeProps & import("vue").AllowedComponentProps & import("vue").ComponentCustomProps & import("vue").Plugin<any[]>;
export default _default;
export type { SegmentedProps };
