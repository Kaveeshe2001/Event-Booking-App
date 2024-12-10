import './textarea.css';

type TextareraProps = {
    label? :string;
    id: string;
    name: string;
    placeholder? : string;
    onChange? : (e: React.ChangeEvent<HTMLTextAreaElement>) => void;
    value? : string;
    error? : string;
};

const Textarea = ({
    label,
    id,
    name,
    placeholder,
    onChange,
    value,
    error,
}: TextareraProps) => {
  return (
    <div className='form-inner'>
      {label && <label htmlFor={id}>{label}</label>}
      <textarea
        name={name}
        id={id}
        placeholder={placeholder}
        value={value}
        onChange={onChange}></textarea>
        {error && <span className='error-message'>{error}</span>}
    </div>
  );
};

export default Textarea;
