import { Modal as MTNModal } from "@mantine/core";
import type { ModalProps, ModalRootProps } from "@mantine/core";
import type { FC, ReactNode } from "react";
import { Button } from "../components/Button";
import { IconButton } from "./IconButton";
import { X } from "lucide-react";

interface MoreModalProps extends ModalProps {
  header?: ReactNode;
  excludeFooter?: boolean;
  classNames?: {
    content: string;
    header: string;
  };
}
export const Modal: FC<MoreModalProps> = ({
  onClose,
  opened,
  title,
  children,
  excludeFooter,
  classNames,
  closeOnEscape = true,
  header,
  ...rest
}) => {
  return (
    <MTNModal.Root
      {...(rest as ModalRootProps)}
      opened={opened}
      onClose={onClose}
      closeOnEscape={closeOnEscape}
      className={`h-dvh w-dvw bg-transparent absolute top-0 left-0 flex justify-center items-center ${
        !opened && "hidden"
      }`}
    >
      <MTNModal.Overlay className="h-full w-full bg-black/50 absolute top-0 left-0" />
      <MTNModal.Content className="">
        <div
          className={`bg-white min-h-80 min-w-100 px-8 pt-8 pb-4 grid grid-rows-[min-content_auto_min-content] rounded ${classNames?.content}`}
        >
          <MTNModal.Header className="">
            {title && (
              <>
                <IconButton
                  className="absolute -top-2 -right-2 rounded-full bg-slate-200"
                  size="xs"
                  onClick={onClose}
                >
                  <X />
                </IconButton>
                <MTNModal.Title className="text-lg font-semibold">
                  {title}
                </MTNModal.Title>
                {header}
              </>
            )}
          </MTNModal.Header>
          <MTNModal.Body className="flex">{children}</MTNModal.Body>
          {!excludeFooter && (
            <div className="flex justify-end gap-2.5">
              <Button onClick={onClose}>Cancel</Button>
              <Button onClick={onClose} color="primary">
                Submit
              </Button>
            </div>
          )}
        </div>
      </MTNModal.Content>
    </MTNModal.Root>
  );
};
