import type { App } from 'vue';
import type { PickerTimeProps, RangePickerTimeProps } from '../date-picker/generatePicker';
declare const TimePicker: import("vue").DefineComponent<import("./time-picker").TimePickerProps<Date>, {}, {}, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, {}, string, import("vue").PublicProps, Readonly<import("./time-picker").TimePickerProps<Date>>, {}, {}>, TimeRangePicker: import("vue").DefineComponent<import("./time-picker").TimeRangePickerProps<Date>, {}, {}, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, {}, string, import("vue").PublicProps, Readonly<import("./time-picker").TimeRangePickerProps<Date>>, {}, {}>;
export interface TimeRangePickerProps extends Omit<RangePickerTimeProps<Date>, 'picker'> {
    popupClassName?: string;
    valueFormat?: string;
}
export interface TimePickerProps extends Omit<PickerTimeProps<Date>, 'picker'> {
    popupClassName?: string;
    valueFormat?: string;
}
export { TimePicker, TimeRangePicker };
declare const _default: {
    new (...args: any[]): import("vue").CreateComponentPublicInstance<Readonly<import("./time-picker").TimePickerProps<Date>>, {}, {}, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, {}, import("vue").VNodeProps & import("vue").AllowedComponentProps & import("vue").ComponentCustomProps & Readonly<import("./time-picker").TimePickerProps<Date>>, {}, true, {}, {}, {
        P: {};
        B: {};
        D: {};
        C: {};
        M: {};
        Defaults: {};
    }, Readonly<import("./time-picker").TimePickerProps<Date>>, {}, {}, {}, {}, {}>;
    __isFragment?: never;
    __isTeleport?: never;
    __isSuspense?: never;
} & import("vue").ComponentOptionsBase<Readonly<import("./time-picker").TimePickerProps<Date>>, {}, {}, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, {}, string, {}, {}, string, {}> & import("vue").VNodeProps & import("vue").AllowedComponentProps & import("vue").ComponentCustomProps & {
    TimePicker: import("vue").DefineComponent<import("./time-picker").TimePickerProps<Date>, {}, {}, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, {}, string, import("vue").PublicProps, Readonly<import("./time-picker").TimePickerProps<Date>>, {}, {}>;
    TimeRangePicker: import("vue").DefineComponent<import("./time-picker").TimeRangePickerProps<Date>, {}, {}, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, {}, string, import("vue").PublicProps, Readonly<import("./time-picker").TimeRangePickerProps<Date>>, {}, {}>;
    install: (app: App) => App<any>;
};
export default _default;
