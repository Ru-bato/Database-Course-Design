import type { CSSProperties, PropType } from 'vue';
import type { MouseEventHandler } from '../../_util/EventInterface';
import PreviewGroup from './PreviewGroup';
import type { IDialogChildProps } from '../../vc-dialog/IDialogPropTypes';
export type GetContainer = string | HTMLElement | (() => HTMLElement);
import type { PreviewProps } from './Preview';
export type ImagePreviewType = Omit<IDialogChildProps, 'mask' | 'visible' | 'closable' | 'prefixCls' | 'onClose' | 'afterClose' | 'wrapClassName'> & {
    src?: string;
    visible?: boolean;
    onVisibleChange?: (value: boolean, prevValue: boolean) => void;
    getContainer?: GetContainer | false;
    maskClassName?: string;
    icons?: PreviewProps['icons'];
};
export declare const imageProps: () => {
    src: StringConstructor;
    wrapperClassName: StringConstructor;
    wrapperStyle: {
        type: PropType<CSSProperties>;
        default: CSSProperties;
    };
    rootClassName: StringConstructor;
    prefixCls: StringConstructor;
    previewPrefixCls: StringConstructor;
    previewMask: {
        type: PropType<false | (() => any)>;
        default: any;
    };
    placeholder: import("vue-types").VueTypeValidableDef<any>;
    fallback: StringConstructor;
    preview: {
        type: PropType<boolean | ImagePreviewType>;
        default: boolean | ImagePreviewType;
    };
    onClick: {
        type: PropType<MouseEventHandler>;
    };
    onError: {
        type: PropType<OnErrorEventHandlerNonNull>;
    };
};
export type ImageProps = Partial<ReturnType<typeof imageProps>>;
export type ImageStatus = 'normal' | 'error' | 'loading';
export declare const mergeDefaultValue: <T extends object>(obj: T, defaultValues: object) => T;
declare const _default: {
    new (...args: any[]): import("vue").CreateComponentPublicInstance<Readonly<import("vue").ExtractPropTypes<{
        src: StringConstructor;
        wrapperClassName: StringConstructor;
        wrapperStyle: {
            type: PropType<CSSProperties>;
            default: CSSProperties;
        };
        rootClassName: StringConstructor;
        prefixCls: StringConstructor;
        previewPrefixCls: StringConstructor;
        previewMask: {
            type: PropType<false | (() => any)>;
            default: any;
        };
        placeholder: import("vue-types").VueTypeValidableDef<any>;
        fallback: StringConstructor;
        preview: {
            type: PropType<boolean | ImagePreviewType>;
            default: boolean | ImagePreviewType;
        };
        onClick: {
            type: PropType<MouseEventHandler>;
        };
        onError: {
            type: PropType<OnErrorEventHandlerNonNull>;
        };
    }>> & {
        onClick?: (...args: any[]) => any;
        onError?: (...args: any[]) => any;
    }, () => import("vue/jsx-runtime").JSX.Element, unknown, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, ("click" | "error")[], import("vue").VNodeProps & import("vue").AllowedComponentProps & import("vue").ComponentCustomProps & Readonly<import("vue").ExtractPropTypes<{
        src: StringConstructor;
        wrapperClassName: StringConstructor;
        wrapperStyle: {
            type: PropType<CSSProperties>;
            default: CSSProperties;
        };
        rootClassName: StringConstructor;
        prefixCls: StringConstructor;
        previewPrefixCls: StringConstructor;
        previewMask: {
            type: PropType<false | (() => any)>;
            default: any;
        };
        placeholder: import("vue-types").VueTypeValidableDef<any>;
        fallback: StringConstructor;
        preview: {
            type: PropType<boolean | ImagePreviewType>;
            default: boolean | ImagePreviewType;
        };
        onClick: {
            type: PropType<MouseEventHandler>;
        };
        onError: {
            type: PropType<OnErrorEventHandlerNonNull>;
        };
    }>> & {
        onClick?: (...args: any[]) => any;
        onError?: (...args: any[]) => any;
    }, {
        preview: boolean | ImagePreviewType;
        wrapperStyle: CSSProperties;
        previewMask: false | (() => any);
    }, true, {}, {}, {
        P: {};
        B: {};
        D: {};
        C: {};
        M: {};
        Defaults: {};
    }, Readonly<import("vue").ExtractPropTypes<{
        src: StringConstructor;
        wrapperClassName: StringConstructor;
        wrapperStyle: {
            type: PropType<CSSProperties>;
            default: CSSProperties;
        };
        rootClassName: StringConstructor;
        prefixCls: StringConstructor;
        previewPrefixCls: StringConstructor;
        previewMask: {
            type: PropType<false | (() => any)>;
            default: any;
        };
        placeholder: import("vue-types").VueTypeValidableDef<any>;
        fallback: StringConstructor;
        preview: {
            type: PropType<boolean | ImagePreviewType>;
            default: boolean | ImagePreviewType;
        };
        onClick: {
            type: PropType<MouseEventHandler>;
        };
        onError: {
            type: PropType<OnErrorEventHandlerNonNull>;
        };
    }>> & {
        onClick?: (...args: any[]) => any;
        onError?: (...args: any[]) => any;
    }, () => import("vue/jsx-runtime").JSX.Element, {}, {}, {}, {
        preview: boolean | ImagePreviewType;
        wrapperStyle: CSSProperties;
        previewMask: false | (() => any);
    }>;
    __isFragment?: never;
    __isTeleport?: never;
    __isSuspense?: never;
} & import("vue").ComponentOptionsBase<Readonly<import("vue").ExtractPropTypes<{
    src: StringConstructor;
    wrapperClassName: StringConstructor;
    wrapperStyle: {
        type: PropType<CSSProperties>;
        default: CSSProperties;
    };
    rootClassName: StringConstructor;
    prefixCls: StringConstructor;
    previewPrefixCls: StringConstructor;
    previewMask: {
        type: PropType<false | (() => any)>;
        default: any;
    };
    placeholder: import("vue-types").VueTypeValidableDef<any>;
    fallback: StringConstructor;
    preview: {
        type: PropType<boolean | ImagePreviewType>;
        default: boolean | ImagePreviewType;
    };
    onClick: {
        type: PropType<MouseEventHandler>;
    };
    onError: {
        type: PropType<OnErrorEventHandlerNonNull>;
    };
}>> & {
    onClick?: (...args: any[]) => any;
    onError?: (...args: any[]) => any;
}, () => import("vue/jsx-runtime").JSX.Element, unknown, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, ("click" | "error")[], "click" | "error", {
    preview: boolean | ImagePreviewType;
    wrapperStyle: CSSProperties;
    previewMask: false | (() => any);
}, {}, string, {}> & import("vue").VNodeProps & import("vue").AllowedComponentProps & import("vue").ComponentCustomProps & {
    readonly PreviewGroup: typeof PreviewGroup;
};
export default _default;
