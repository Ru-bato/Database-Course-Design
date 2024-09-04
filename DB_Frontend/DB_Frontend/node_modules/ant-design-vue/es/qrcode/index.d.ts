import type { ExtractPropTypes } from 'vue';
import { qrcodeProps } from './interface';
export type QRCodeProps = Partial<ExtractPropTypes<ReturnType<typeof qrcodeProps>>>;
declare const _default: {
    new (...args: any[]): import("vue").CreateComponentPublicInstance<Readonly<ExtractPropTypes<{
        errorLevel: {
            type: import("vue").PropType<"M" | "H" | "Q" | "L">;
            default: "M" | "H" | "Q" | "L";
        };
        icon: StringConstructor;
        iconSize: {
            type: NumberConstructor;
            default: number;
        };
        status: {
            type: import("vue").PropType<"active" | "loading" | "expired" | "scanned">;
            default: "active" | "loading" | "expired" | "scanned";
        };
        bordered: {
            type: BooleanConstructor;
            default: boolean;
        };
        size: {
            type: NumberConstructor;
            default: number;
        };
        value: {
            type: StringConstructor;
            required: boolean;
        };
        type: {
            type: import("vue").PropType<"canvas" | "svg">;
            default: "canvas" | "svg";
        };
        color: StringConstructor;
        bgColor: StringConstructor;
        includeMargin: BooleanConstructor;
        imageSettings: {
            type: import("vue").PropType<import("./interface").ImageSettings>;
            default: import("./interface").ImageSettings;
        };
    }>> & {
        onRefresh?: (...args: any[]) => any;
    }, () => import("../_util/type").VueNode, unknown, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, "refresh"[], import("vue").VNodeProps & import("vue").AllowedComponentProps & import("vue").ComponentCustomProps & Readonly<ExtractPropTypes<{
        errorLevel: {
            type: import("vue").PropType<"M" | "H" | "Q" | "L">;
            default: "M" | "H" | "Q" | "L";
        };
        icon: StringConstructor;
        iconSize: {
            type: NumberConstructor;
            default: number;
        };
        status: {
            type: import("vue").PropType<"active" | "loading" | "expired" | "scanned">;
            default: "active" | "loading" | "expired" | "scanned";
        };
        bordered: {
            type: BooleanConstructor;
            default: boolean;
        };
        size: {
            type: NumberConstructor;
            default: number;
        };
        value: {
            type: StringConstructor;
            required: boolean;
        };
        type: {
            type: import("vue").PropType<"canvas" | "svg">;
            default: "canvas" | "svg";
        };
        color: StringConstructor;
        bgColor: StringConstructor;
        includeMargin: BooleanConstructor;
        imageSettings: {
            type: import("vue").PropType<import("./interface").ImageSettings>;
            default: import("./interface").ImageSettings;
        };
    }>> & {
        onRefresh?: (...args: any[]) => any;
    }, {
        size: number;
        type: "canvas" | "svg";
        status: "active" | "loading" | "expired" | "scanned";
        bordered: boolean;
        includeMargin: boolean;
        imageSettings: import("./interface").ImageSettings;
        errorLevel: "M" | "H" | "Q" | "L";
        iconSize: number;
    }, true, {}, {}, {
        P: {};
        B: {};
        D: {};
        C: {};
        M: {};
        Defaults: {};
    }, Readonly<ExtractPropTypes<{
        errorLevel: {
            type: import("vue").PropType<"M" | "H" | "Q" | "L">;
            default: "M" | "H" | "Q" | "L";
        };
        icon: StringConstructor;
        iconSize: {
            type: NumberConstructor;
            default: number;
        };
        status: {
            type: import("vue").PropType<"active" | "loading" | "expired" | "scanned">;
            default: "active" | "loading" | "expired" | "scanned";
        };
        bordered: {
            type: BooleanConstructor;
            default: boolean;
        };
        size: {
            type: NumberConstructor;
            default: number;
        };
        value: {
            type: StringConstructor;
            required: boolean;
        };
        type: {
            type: import("vue").PropType<"canvas" | "svg">;
            default: "canvas" | "svg";
        };
        color: StringConstructor;
        bgColor: StringConstructor;
        includeMargin: BooleanConstructor;
        imageSettings: {
            type: import("vue").PropType<import("./interface").ImageSettings>;
            default: import("./interface").ImageSettings;
        };
    }>> & {
        onRefresh?: (...args: any[]) => any;
    }, () => import("../_util/type").VueNode, {}, {}, {}, {
        size: number;
        type: "canvas" | "svg";
        status: "active" | "loading" | "expired" | "scanned";
        bordered: boolean;
        includeMargin: boolean;
        imageSettings: import("./interface").ImageSettings;
        errorLevel: "M" | "H" | "Q" | "L";
        iconSize: number;
    }>;
    __isFragment?: never;
    __isTeleport?: never;
    __isSuspense?: never;
} & import("vue").ComponentOptionsBase<Readonly<ExtractPropTypes<{
    errorLevel: {
        type: import("vue").PropType<"M" | "H" | "Q" | "L">;
        default: "M" | "H" | "Q" | "L";
    };
    icon: StringConstructor;
    iconSize: {
        type: NumberConstructor;
        default: number;
    };
    status: {
        type: import("vue").PropType<"active" | "loading" | "expired" | "scanned">;
        default: "active" | "loading" | "expired" | "scanned";
    };
    bordered: {
        type: BooleanConstructor;
        default: boolean;
    };
    size: {
        type: NumberConstructor;
        default: number;
    };
    value: {
        type: StringConstructor;
        required: boolean;
    };
    type: {
        type: import("vue").PropType<"canvas" | "svg">;
        default: "canvas" | "svg";
    };
    color: StringConstructor;
    bgColor: StringConstructor;
    includeMargin: BooleanConstructor;
    imageSettings: {
        type: import("vue").PropType<import("./interface").ImageSettings>;
        default: import("./interface").ImageSettings;
    };
}>> & {
    onRefresh?: (...args: any[]) => any;
}, () => import("../_util/type").VueNode, unknown, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, "refresh"[], "refresh", {
    size: number;
    type: "canvas" | "svg";
    status: "active" | "loading" | "expired" | "scanned";
    bordered: boolean;
    includeMargin: boolean;
    imageSettings: import("./interface").ImageSettings;
    errorLevel: "M" | "H" | "Q" | "L";
    iconSize: number;
}, {}, string, {}> & import("vue").VNodeProps & import("vue").AllowedComponentProps & import("vue").ComponentCustomProps & import("vue").Plugin<any[]>;
export default _default;
